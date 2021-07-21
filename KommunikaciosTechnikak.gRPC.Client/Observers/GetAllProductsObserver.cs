using KommunikaciosTechnikak.gRPC.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.gRPC.Client.Observers
{
    public class GetAllProductsObserver : IObserver<ProductModel>
    {
        private IDisposable unsubscriber;

        public virtual void Subscribe(IObservable<ProductModel> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine("Get all products finished!");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Unexpected error: {error.Message}");
        }

        public void OnNext(ProductModel value)
        {
            Console.WriteLine($"Name: {value.Name}, ProductNumber: {value.ProductNumber}");
        }
    }
}
