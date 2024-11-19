using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Recetas.Application.Feature;
using Recetas.Application.RequestManager.Commands;
using Recetas.Domain.Dto;
using Recetas.Domain.Services.Interfaces.Recetas;
using System.Runtime.CompilerServices;
using System.Text;

namespace Recetas.Application.RequestManager.Handlers
{
    public class PostReceiveCreateRecetasCommandHandler : IRequestHandler<PostReceiveCreateRecetasCommand, IActionResult>
    {
        private readonly IRecertaRepository _recetaRepository;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public PostReceiveCreateRecetasCommandHandler(IMapper mapper, IRecertaRepository recertaRepository, IServiceProvider serviceProvider)
        {
            this._recetaRepository = recertaRepository;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(PostReceiveCreateRecetasCommand request, CancellationToken cancellationToken)
        {
            
            
            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";

            var mensajef = "";

            // Crear la conexión y el canal
            IConnection conn = await factory.CreateConnectionAsync();
            IChannel channel = await conn.CreateChannelAsync();

            // Declarar una cola (asegurarse que exista)
            string queueName = "mi_cola_v7";
            channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // Configurar el consumidor
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync +=  async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var mensaje = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x] Recibido: {mensaje}");
                    //mensajef = mensaje;
                    if (!string.IsNullOrEmpty(mensaje))
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var myModel = JsonConvert.DeserializeObject<CreateRecetasRequest>(mensaje);
                            var Entitymapper = _mapper.Map<Domain.Entitites.Recetas>(myModel);
                            Entitymapper.IdReceta = Guid.NewGuid();
                            var dbcontex = scope.ServiceProvider.GetRequiredService<IDataBaseService>();
                            dbcontex.Recetas.Add(Entitymapper);
                            dbcontex.SaveAsync();
                           

                        }

                           
                    }

                   
                }
                catch (Exception)
                {

                    throw;
                }

                await Task.Delay(5000);

            };

      

            // Consumir mensajes de la cola
            channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: true,
                consumer: consumer);

            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Receta creada y recibida");

        }

    }
}
