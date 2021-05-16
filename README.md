1. I want to manage multiple wallets as part of an 'account'
2. I want to open a wallet and have it spwan it's own RPC

POST /wallet/{id}/rpc { ... } => json
    200 - The API did not error
    404 - No such wallet file
    400 - RPC error
    503 - Maximum pool number has been reached
    503 - Monero wallet RPC could not be spaned / daemon not available

POST /wallet/{id}/open { password, ...params } => url | error
    200 - The wallet has already spawned an RPC, returns same URL
    201 - A new RPC was spwaned, returns url
    404 - No such wallet file
    503 - Maximum pool number has been reached
    503 - Monero wallet RPC could not be spaned / daemon not available

PUT /wallet/{id}/close
    404 - No such wallet file
    200 - Wallet was closed down or was already closed



POST /wallet/{id}/payment-url ?note ?amount ?qr { password, callback_url } => url | qr | error
    404 - No such wallet file
    429 - Too many requests made
    503 - A pool could not be spanwed
    503 - Monero wallet RPC could not be spaned / daemon not available
    201 - New payment url was created and returns either url or qr

POST /account/{id}


```csharp



using (var wallet = Monero.OpenWallet("name"))
{
    wallet.Open
}

```