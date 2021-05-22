```
Account (id, password)
  \_* Wallet (id, cache, keys)
      |\_* Transfer (id, payment_id?, type, amount, free, date)
       \__|__* IntegratedAddress (id, payment_id, reference, qr, url, on_transfer_url)
          |     \_ ReistributionScheme (id, status, type, payout_threshold?)
          |        |\_ DynamicRedistributionScheme (get_recipients_url, on_redistributed_url)
          |        |\_ StaticRedistributionScheme
          |        |   \_* StaticRedistribtionSchemeShare (address, percentage)                   
          \________|\_* Redistribution (id)
                     
POST /accounts { password }                                                                                                          -> id
GET  /accounts/{id} { password }                                                                                                     -> OK     
POST /accounts/{id}/sync { password }                                                                                                -> id
GET  /accounts/{id}/wallets { password }                                                                                             -> { id, cache, keys }[]
GET  /accounts/{id}/wallets/{id} { password }                                                                                        -> { id, cache, keys }[]
POST /accounts/{id}/wallets/{id}/sync { password }                                                                                   -> OK
POST /accounts/{id}/wallets { password, cache, keys}                                                                                 -> id
POST /accounts/{id}/integrated_addresses  { account_password, on_transfer_url, reference, message, amount? }                         -> id
PUT  /accounts/{id}/integrated_addresses/{id}/redistribution_scheme { account_password, get_destinations_url, on_redistributed_url } -> OK
GET  /accounts/{id}/integrated_addresses/{id}/qr                                                                                     -> OK                                        
GET  /accounts/{id}/integrated_addresses/{id}/url    
```