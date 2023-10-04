using ProvaPub.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaPub.Services
{
    public class OrderService
    {
        private readonly Dictionary<string, IPaymentProcessor> paymentProcessors;

        public OrderService()
        {
            paymentProcessors = new Dictionary<string, IPaymentProcessor>
            {
                {"pix", new PixPaymentProcessor()},
                {"creditcard", new CreditCardPaymentProcessor()},
                {"paypal", new PayPalPaymentProcessor()},
                //  outros métodos de pagamento aqui
            };
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentProcessors.TryGetValue(paymentMethod, out var paymentProcessor))
            {
                // Chama o processador de pagamento correspondente
                return await paymentProcessor.ProcessPayment(paymentValue, customerId);
            }
            else
            {
                throw new NotSupportedException("Método de pagamento não suportado");
            }
        }
    }

    public interface IPaymentProcessor
    {
        Task<Order> ProcessPayment(decimal paymentValue, int customerId);
    }


    public class PixPaymentProcessor : IPaymentProcessor
    {
        public async Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order() { Value = paymentValue });
        }
    }

    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public async Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order() { Value = paymentValue });
        }
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public async Task<Order> ProcessPayment(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order() { Value = paymentValue });
        }
    }

}
