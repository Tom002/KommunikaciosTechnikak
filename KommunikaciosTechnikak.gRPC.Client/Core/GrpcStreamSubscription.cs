using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.gRPC.Client.Core
{
    public class GrpcStreamSubscription<T> : IDisposable
    {
        private readonly IAsyncStreamReader<T> _reader;
        private readonly IObserver<T> _observer;

        private readonly CancellationTokenSource _tokenSource;

        private readonly Task _task;

        private bool _completed;

        public GrpcStreamSubscription(IAsyncStreamReader<T> reader, IObserver<T> observer, CancellationToken token = default)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));

            _tokenSource = new CancellationTokenSource();
            token.Register(_tokenSource.Cancel);

            _task = Run(_tokenSource.Token);
        }

        private async Task Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!await _reader.MoveNext(token)) break;
                }
                catch (RpcException e) when (e.StatusCode == Grpc.Core.StatusCode.NotFound)
                {
                    break;
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception e)
                {
                    _observer.OnError(e);
                    _completed = true;
                    return;
                }

                _observer.OnNext(_reader.Current);
            }

            _completed = true;
            _observer.OnCompleted();
        }

        public void Dispose()
        {
            if (!_completed && !_tokenSource.IsCancellationRequested)
            {
                _tokenSource.Cancel();
            }

            _tokenSource.Dispose();
            _task.Dispose();
        }

    }
}
