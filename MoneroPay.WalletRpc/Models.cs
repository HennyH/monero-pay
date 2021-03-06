namespace MoneroPay.WalletRpc.Models
{
    using System;
    using System.Text.Json.Serialization;
    using System.Collections.Generic;

    public class PerSubaddressInfo
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("address_index")]
        public Int32 AddressIndex { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; }
        [JsonPropertyName("unlocked_balance")]
        public Int64 UnlockedBalance { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }
        [JsonPropertyName("num_unspent_outputs")]
        public Int64 NumUnspentOutputs { get; set; }
        [JsonPropertyName("blocks_to_unlock")]
        public Int64 BlocksToUnlock { get; set; }
        [JsonPropertyName("time_to_unlock")]
        public Int64 TimeToUnlock { get; set; }

        public PerSubaddressInfo(Int32 accountIndex, Int32 addressIndex, String address, Int64 balance, Int64 unlockedBalance, String label, Int64 numUnspentOutputs, Int64 blocksToUnlock, Int64 timeToUnlock)
        {
            this.AccountIndex = accountIndex;
            this.AddressIndex = addressIndex;
            this.Address = address;
            this.Balance = balance;
            this.UnlockedBalance = unlockedBalance;
            this.Label = label;
            this.NumUnspentOutputs = numUnspentOutputs;
            this.BlocksToUnlock = blocksToUnlock;
            this.TimeToUnlock = timeToUnlock;
        }
    }

    public class AddressInfo
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }
        [JsonPropertyName("address_index")]
        public Int32 AddressIndex { get; set; }
        [JsonPropertyName("used")]
        public Boolean Used { get; set; }

        public AddressInfo(String address, String label, Int32 addressIndex, Boolean used)
        {
            this.Address = address;
            this.Label = label;
            this.AddressIndex = addressIndex;
            this.Used = used;
        }
    }

    public class SubaddressAccountInfo
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("base_address")]
        public String BaseAddress { get; set; }
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; }
        [JsonPropertyName("unlocked_balance")]
        public Int64 UnlockedBalance { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }
        [JsonPropertyName("tag")]
        public String Tag { get; set; }

        public SubaddressAccountInfo(Int32 accountIndex, String baseAddress, Int64 balance, Int64 unlockedBalance, String label, String tag)
        {
            this.AccountIndex = accountIndex;
            this.BaseAddress = baseAddress;
            this.Balance = balance;
            this.UnlockedBalance = unlockedBalance;
            this.Label = label;
            this.Tag = tag;
        }
    }

    public class AccountTagInfo
    {
        [JsonPropertyName("tag")]
        public String Tag { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }
        [JsonPropertyName("accounts")]
        public List<Int32> Accounts { get; set; }

        public AccountTagInfo(String tag, String label, List<Int32> accounts)
        {
            this.Tag = tag;
            this.Label = label;
            this.Accounts = accounts;
        }
    }

    public class TransferDestination
    {
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public TransferDestination(Int64 amount, String address)
        {
            this.Amount = amount;
            this.Address = address;
        }
    }

    public class KeyList
    {
        [JsonPropertyName("keys")]
        public List<String> Keys { get; set; }

        public KeyList(List<String> keys)
        {
            this.Keys = keys;
        }
    }

    public class Recipient
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }

        public Recipient(String address, Int64 amount)
        {
            this.Address = address;
            this.Amount = amount;
        }
    }

    public class TransferDescription
    {
        [JsonPropertyName("amount_in")]
        public Int64 AmountIn { get; set; }
        [JsonPropertyName("amount_out")]
        public Int64 AmountOut { get; set; }
        [JsonPropertyName("ring_size")]
        public Int32 RingSize { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("recipients")]
        public List<Recipient> Recipients { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("change_amount")]
        public Int64 ChangeAmount { get; set; }
        [JsonPropertyName("change_address")]
        public String ChangeAddress { get; set; }
        [JsonPropertyName("fee")]
        public Int64 Fee { get; set; }
        [JsonPropertyName("dummy_outputs")]
        public Int32 DummyOutputs { get; set; }
        [JsonPropertyName("extra")]
        public String Extra { get; set; }

        public TransferDescription(Int64 amountIn, Int64 amountOut, Int32 ringSize, Int64 unlockTime, List<Recipient> recipients, String paymentId, Int64 changeAmount, String changeAddress, Int64 fee, Int32 dummyOutputs, String extra)
        {
            this.AmountIn = amountIn;
            this.AmountOut = amountOut;
            this.RingSize = ringSize;
            this.UnlockTime = unlockTime;
            this.Recipients = recipients;
            this.PaymentId = paymentId;
            this.ChangeAmount = changeAmount;
            this.ChangeAddress = changeAddress;
            this.Fee = fee;
            this.DummyOutputs = dummyOutputs;
            this.Extra = extra;
        }
    }

    public class PaymentDetails
    {
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("tx_hash")]
        public String TxHash { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("block_height")]
        public Int64 BlockHeight { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("locked")]
        public Boolean Locked { get; set; }
        [JsonPropertyName("subaddr_index")]
        public SubaddressIndex SubaddrIndex { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public PaymentDetails(String paymentId, String txHash, Int64 amount, Int64 blockHeight, Int64 unlockTime, Boolean locked, SubaddressIndex subaddrIndex, String address)
        {
            this.PaymentId = paymentId;
            this.TxHash = txHash;
            this.Amount = amount;
            this.BlockHeight = blockHeight;
            this.UnlockTime = unlockTime;
            this.Locked = locked;
            this.SubaddrIndex = subaddrIndex;
            this.Address = address;
        }
    }

    public class TransferDetails
    {
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("spent")]
        public Boolean Spent { get; set; }
        [JsonPropertyName("global_index")]
        public Int64 GlobalIndex { get; set; }
        [JsonPropertyName("tx_hash")]
        public String TxHash { get; set; }
        [JsonPropertyName("subaddr_index")]
        public SubaddressIndex SubaddrIndex { get; set; }
        [JsonPropertyName("key_image")]
        public String KeyImage { get; set; }
        [JsonPropertyName("pubkey")]
        public String Pubkey { get; set; }
        [JsonPropertyName("block_height")]
        public Int64 BlockHeight { get; set; }
        [JsonPropertyName("frozen")]
        public Boolean Frozen { get; set; }
        [JsonPropertyName("unlocked")]
        public Boolean Unlocked { get; set; }

        public TransferDetails(Int64 amount, Boolean spent, Int64 globalIndex, String txHash, SubaddressIndex subaddrIndex, String keyImage, String pubkey, Int64 blockHeight, Boolean frozen, Boolean unlocked)
        {
            this.Amount = amount;
            this.Spent = spent;
            this.GlobalIndex = globalIndex;
            this.TxHash = txHash;
            this.SubaddrIndex = subaddrIndex;
            this.KeyImage = keyImage;
            this.Pubkey = pubkey;
            this.BlockHeight = blockHeight;
            this.Frozen = frozen;
            this.Unlocked = unlocked;
        }
    }

    public class TransferEntry
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("height")]
        public Int64 Height { get; set; }
        [JsonPropertyName("timestamp")]
        public Int64 Timestamp { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("amounts")]
        public List<Int64> Amounts { get; set; }
        [JsonPropertyName("fee")]
        public Int64 Fee { get; set; }
        [JsonPropertyName("note")]
        public String Note { get; set; }
        [JsonPropertyName("destinations")]
        public List<TransferDestination> Destinations { get; set; }
        [JsonPropertyName("type")]
        public String Type { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("locked")]
        public Boolean Locked { get; set; }
        [JsonPropertyName("subaddr_index")]
        public SubaddressIndex SubaddrIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public List<SubaddressIndex> SubaddrIndices { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("double_spend_seen")]
        public Boolean DoubleSpendSeen { get; set; }
        [JsonPropertyName("confirmations")]
        public Int64 Confirmations { get; set; }
        [JsonPropertyName("suggested_confirmations_threshold")]
        public Int64 SuggestedConfirmationsThreshold { get; set; }

        public TransferEntry(String txid, String paymentId, Int64 height, Int64 timestamp, Int64 amount, List<Int64> amounts, Int64 fee, String note, List<TransferDestination> destinations, String type, Int64 unlockTime, Boolean locked, SubaddressIndex subaddrIndex, List<SubaddressIndex> subaddrIndices, String address, Boolean doubleSpendSeen, Int64 confirmations, Int64 suggestedConfirmationsThreshold)
        {
            this.Txid = txid;
            this.PaymentId = paymentId;
            this.Height = height;
            this.Timestamp = timestamp;
            this.Amount = amount;
            this.Amounts = amounts;
            this.Fee = fee;
            this.Note = note;
            this.Destinations = destinations;
            this.Type = type;
            this.UnlockTime = unlockTime;
            this.Locked = locked;
            this.SubaddrIndex = subaddrIndex;
            this.SubaddrIndices = subaddrIndices;
            this.Address = address;
            this.DoubleSpendSeen = doubleSpendSeen;
            this.Confirmations = confirmations;
            this.SuggestedConfirmationsThreshold = suggestedConfirmationsThreshold;
        }
    }

    public class SignedKeyImage
    {
        [JsonPropertyName("key_image")]
        public String KeyImage { get; set; }
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public SignedKeyImage(String keyImage, String signature)
        {
            this.KeyImage = keyImage;
            this.Signature = signature;
        }
    }

    public class UriSpec
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("tx_description")]
        public String TxDescription { get; set; }
        [JsonPropertyName("recipient_name")]
        public String RecipientName { get; set; }

        public UriSpec(String address, String paymentId, Int64 amount, String txDescription, String recipientName)
        {
            this.Address = address;
            this.PaymentId = paymentId;
            this.Amount = amount;
            this.TxDescription = txDescription;
            this.RecipientName = recipientName;
        }
    }

    public class Entry
    {
        [JsonPropertyName("index")]
        public Int64 Index { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }

        public Entry(Int64 index, String address, String description)
        {
            this.Index = index;
            this.Address = address;
            this.Description = description;
        }
    }

    public class Request
    {
        [JsonPropertyName("restore_height")]
        public Int64 RestoreHeight { get; set; }
        [JsonPropertyName("filename")]
        public String Filename { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("spendkey")]
        public String Spendkey { get; set; }
        [JsonPropertyName("viewkey")]
        public String Viewkey { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("autosave_current")]
        public Boolean AutosaveCurrent { get; set; }
        [JsonPropertyName("language")]
        public String Language { get; set; }

        public Request(Int64 restoreHeight, String filename, String address, String spendkey, String viewkey, String password, Boolean autosaveCurrent, String language)
        {
            this.RestoreHeight = restoreHeight;
            this.Filename = filename;
            this.Address = address;
            this.Spendkey = spendkey;
            this.Viewkey = viewkey;
            this.Password = password;
            this.AutosaveCurrent = autosaveCurrent;
            this.Language = language;
        }
    }

    public class Response
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("info")]
        public String Info { get; set; }

        public Response(String address, String info)
        {
            this.Address = address;
            this.Info = info;
        }
    }

    public class SubaddressIndex
    {
        [JsonPropertyName("major")]
        public Int32 Major { get; set; }
        [JsonPropertyName("minor")]
        public Int32 Minor { get; set; }

        public SubaddressIndex(Int32 major, Int32 minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }

    public class GetBalanceParameters
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("address_indices")]
        public HashSet<Int32> AddressIndices { get; set; }
        [JsonPropertyName("all_accounts")]
        public Boolean AllAccounts { get; set; }
        [JsonPropertyName("strict")]
        public Boolean Strict { get; set; }

        public GetBalanceParameters(Int32 accountIndex, HashSet<Int32> addressIndices, Boolean allAccounts, Boolean strict)
        {
            this.AccountIndex = accountIndex;
            this.AddressIndices = addressIndices;
            this.AllAccounts = allAccounts;
            this.Strict = strict;
        }
    }

    public class GetBalanceResult
    {
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; }
        [JsonPropertyName("unlocked_balance")]
        public Int64 UnlockedBalance { get; set; }
        [JsonPropertyName("multisig_import_needed")]
        public Boolean MultisigImportNeeded { get; set; }
        [JsonPropertyName("per_subaddress")]
        public List<PerSubaddressInfo> PerSubaddress { get; set; }
        [JsonPropertyName("blocks_to_unlock")]
        public Int64 BlocksToUnlock { get; set; }
        [JsonPropertyName("time_to_unlock")]
        public Int64 TimeToUnlock { get; set; }

        public GetBalanceResult(Int64 balance, Int64 unlockedBalance, Boolean multisigImportNeeded, List<PerSubaddressInfo> perSubaddress, Int64 blocksToUnlock, Int64 timeToUnlock)
        {
            this.Balance = balance;
            this.UnlockedBalance = unlockedBalance;
            this.MultisigImportNeeded = multisigImportNeeded;
            this.PerSubaddress = perSubaddress;
            this.BlocksToUnlock = blocksToUnlock;
            this.TimeToUnlock = timeToUnlock;
        }
    }

    public class GetAddressParameters
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("address_index")]
        public List<Int32> AddressIndex { get; set; }

        public GetAddressParameters(Int32 accountIndex, List<Int32> addressIndex)
        {
            this.AccountIndex = accountIndex;
            this.AddressIndex = addressIndex;
        }
    }

    public class GetAddressResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("addresses")]
        public List<AddressInfo> Addresses { get; set; }

        public GetAddressResult(String address, List<AddressInfo> addresses)
        {
            this.Address = address;
            this.Addresses = addresses;
        }
    }

    public class GetAddressIndexParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public GetAddressIndexParameters(String address)
        {
            this.Address = address;
        }
    }

    public class GetAddressIndexResult
    {
        [JsonPropertyName("index")]
        public SubaddressIndex Index { get; set; }

        public GetAddressIndexResult(SubaddressIndex index)
        {
            this.Index = index;
        }
    }

    public class CreateAddressParameters
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("count")]
        public Int32 Count { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }

        public CreateAddressParameters(Int32 accountIndex, Int32 count, String label)
        {
            this.AccountIndex = accountIndex;
            this.Count = count;
            this.Label = label;
        }
    }

    public class CreateAddressResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("address_index")]
        public Int32 AddressIndex { get; set; }
        [JsonPropertyName("addresses")]
        public List<String> Addresses { get; set; }
        [JsonPropertyName("address_indices")]
        public List<Int32> AddressIndices { get; set; }

        public CreateAddressResult(String address, Int32 addressIndex, List<String> addresses, List<Int32> addressIndices)
        {
            this.Address = address;
            this.AddressIndex = addressIndex;
            this.Addresses = addresses;
            this.AddressIndices = addressIndices;
        }
    }

    public class LabelAddressParameters
    {
        [JsonPropertyName("index")]
        public SubaddressIndex Index { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }

        public LabelAddressParameters(SubaddressIndex index, String label)
        {
            this.Index = index;
            this.Label = label;
        }
    }

    public class LabelAddressResult
    {
        public LabelAddressResult()
        {
        }
    }

    public class GetAccountsParameters
    {
        [JsonPropertyName("tag")]
        public String Tag { get; set; }
        [JsonPropertyName("strict_balances")]
        public Boolean StrictBalances { get; set; }

        public GetAccountsParameters(String tag, Boolean strictBalances)
        {
            this.Tag = tag;
            this.StrictBalances = strictBalances;
        }
    }

    public class GetAccountsResult
    {
        [JsonPropertyName("total_balance")]
        public Int64 TotalBalance { get; set; }
        [JsonPropertyName("total_unlocked_balance")]
        public Int64 TotalUnlockedBalance { get; set; }
        [JsonPropertyName("subaddress_accounts")]
        public List<SubaddressAccountInfo> SubaddressAccounts { get; set; }

        public GetAccountsResult(Int64 totalBalance, Int64 totalUnlockedBalance, List<SubaddressAccountInfo> subaddressAccounts)
        {
            this.TotalBalance = totalBalance;
            this.TotalUnlockedBalance = totalUnlockedBalance;
            this.SubaddressAccounts = subaddressAccounts;
        }
    }

    public class CreateAccountParameters
    {
        [JsonPropertyName("label")]
        public String Label { get; set; }

        public CreateAccountParameters(String label)
        {
            this.Label = label;
        }
    }

    public class CreateAccountResult
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public CreateAccountResult(Int32 accountIndex, String address)
        {
            this.AccountIndex = accountIndex;
            this.Address = address;
        }
    }

    public class LabelAccountParameters
    {
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("label")]
        public String Label { get; set; }

        public LabelAccountParameters(Int32 accountIndex, String label)
        {
            this.AccountIndex = accountIndex;
            this.Label = label;
        }
    }

    public class LabelAccountResult
    {
        public LabelAccountResult()
        {
        }
    }

    public class GetAccountTagsParameters
    {
        public GetAccountTagsParameters()
        {
        }
    }

    public class GetAccountTagsResult
    {
        [JsonPropertyName("account_tags")]
        public List<AccountTagInfo> AccountTags { get; set; }

        public GetAccountTagsResult(List<AccountTagInfo> accountTags)
        {
            this.AccountTags = accountTags;
        }
    }

    public class TagAccountsParameters
    {
        [JsonPropertyName("tag")]
        public String Tag { get; set; }
        [JsonPropertyName("accounts")]
        public HashSet<Int32> Accounts { get; set; }

        public TagAccountsParameters(String tag, HashSet<Int32> accounts)
        {
            this.Tag = tag;
            this.Accounts = accounts;
        }
    }

    public class TagAccountsResult
    {
        public TagAccountsResult()
        {
        }
    }

    public class UntagAccountsParameters
    {
        [JsonPropertyName("accounts")]
        public HashSet<Int32> Accounts { get; set; }

        public UntagAccountsParameters(HashSet<Int32> accounts)
        {
            this.Accounts = accounts;
        }
    }

    public class UntagAccountsResult
    {
        public UntagAccountsResult()
        {
        }
    }

    public class SetAccountTagDescriptionParameters
    {
        [JsonPropertyName("tag")]
        public String Tag { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }

        public SetAccountTagDescriptionParameters(String tag, String description)
        {
            this.Tag = tag;
            this.Description = description;
        }
    }

    public class SetAccountTagDescriptionResult
    {
        public SetAccountTagDescriptionResult()
        {
        }
    }

    public class GetHeightParameters
    {
        public GetHeightParameters()
        {
        }
    }

    public class GetHeightResult
    {
        [JsonPropertyName("height")]
        public Int64 Height { get; set; }

        public GetHeightResult(Int64 height)
        {
            this.Height = height;
        }
    }

    public class TransferParameters
    {
        [JsonPropertyName("destinations")]
        public List<TransferDestination> Destinations { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public HashSet<Int32> SubaddrIndices { get; set; }
        [JsonPropertyName("priority")]
        public Int32 Priority { get; set; }
        [JsonPropertyName("ring_size")]
        public Int64 RingSize { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("get_tx_key")]
        public Boolean GetTxKey { get; set; }
        [JsonPropertyName("do_not_relay")]
        public Boolean DoNotRelay { get; set; }
        [JsonPropertyName("get_tx_hex")]
        public Boolean GetTxHex { get; set; }
        [JsonPropertyName("get_tx_metadata")]
        public Boolean GetTxMetadata { get; set; }

        public TransferParameters(List<TransferDestination> destinations, Int32 accountIndex, HashSet<Int32> subaddrIndices, Int32 priority, Int64 ringSize, Int64 unlockTime, String paymentId, Boolean getTxKey, Boolean doNotRelay, Boolean getTxHex, Boolean getTxMetadata)
        {
            this.Destinations = destinations;
            this.AccountIndex = accountIndex;
            this.SubaddrIndices = subaddrIndices;
            this.Priority = priority;
            this.RingSize = ringSize;
            this.UnlockTime = unlockTime;
            this.PaymentId = paymentId;
            this.GetTxKey = getTxKey;
            this.DoNotRelay = doNotRelay;
            this.GetTxHex = getTxHex;
            this.GetTxMetadata = getTxMetadata;
        }
    }

    public class TransferResult
    {
        [JsonPropertyName("tx_hash")]
        public String TxHash { get; set; }
        [JsonPropertyName("tx_key")]
        public String TxKey { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("fee")]
        public Int64 Fee { get; set; }
        [JsonPropertyName("weight")]
        public Int64 Weight { get; set; }
        [JsonPropertyName("tx_blob")]
        public String TxBlob { get; set; }
        [JsonPropertyName("tx_metadata")]
        public String TxMetadata { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }

        public TransferResult(String txHash, String txKey, Int64 amount, Int64 fee, Int64 weight, String txBlob, String txMetadata, String multisigTxset, String unsignedTxset)
        {
            this.TxHash = txHash;
            this.TxKey = txKey;
            this.Amount = amount;
            this.Fee = fee;
            this.Weight = weight;
            this.TxBlob = txBlob;
            this.TxMetadata = txMetadata;
            this.MultisigTxset = multisigTxset;
            this.UnsignedTxset = unsignedTxset;
        }
    }

    public class TransferSplitParameters
    {
        [JsonPropertyName("destinations")]
        public List<TransferDestination> Destinations { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public HashSet<Int32> SubaddrIndices { get; set; }
        [JsonPropertyName("priority")]
        public Int32 Priority { get; set; }
        [JsonPropertyName("ring_size")]
        public Int64 RingSize { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("get_tx_keys")]
        public Boolean GetTxKeys { get; set; }
        [JsonPropertyName("do_not_relay")]
        public Boolean DoNotRelay { get; set; }
        [JsonPropertyName("get_tx_hex")]
        public Boolean GetTxHex { get; set; }
        [JsonPropertyName("get_tx_metadata")]
        public Boolean GetTxMetadata { get; set; }

        public TransferSplitParameters(List<TransferDestination> destinations, Int32 accountIndex, HashSet<Int32> subaddrIndices, Int32 priority, Int64 ringSize, Int64 unlockTime, String paymentId, Boolean getTxKeys, Boolean doNotRelay, Boolean getTxHex, Boolean getTxMetadata)
        {
            this.Destinations = destinations;
            this.AccountIndex = accountIndex;
            this.SubaddrIndices = subaddrIndices;
            this.Priority = priority;
            this.RingSize = ringSize;
            this.UnlockTime = unlockTime;
            this.PaymentId = paymentId;
            this.GetTxKeys = getTxKeys;
            this.DoNotRelay = doNotRelay;
            this.GetTxHex = getTxHex;
            this.GetTxMetadata = getTxMetadata;
        }
    }

    public class TransferSplitResult
    {
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }
        [JsonPropertyName("tx_key_list")]
        public List<String> TxKeyList { get; set; }
        [JsonPropertyName("amount_list")]
        public List<Int64> AmountList { get; set; }
        [JsonPropertyName("fee_list")]
        public List<Int64> FeeList { get; set; }
        [JsonPropertyName("weight_list")]
        public List<Int64> WeightList { get; set; }
        [JsonPropertyName("tx_blob_list")]
        public List<String> TxBlobList { get; set; }
        [JsonPropertyName("tx_metadata_list")]
        public List<String> TxMetadataList { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }

        public TransferSplitResult(List<String> txHashList, List<String> txKeyList, List<Int64> amountList, List<Int64> feeList, List<Int64> weightList, List<String> txBlobList, List<String> txMetadataList, String multisigTxset, String unsignedTxset)
        {
            this.TxHashList = txHashList;
            this.TxKeyList = txKeyList;
            this.AmountList = amountList;
            this.FeeList = feeList;
            this.WeightList = weightList;
            this.TxBlobList = txBlobList;
            this.TxMetadataList = txMetadataList;
            this.MultisigTxset = multisigTxset;
            this.UnsignedTxset = unsignedTxset;
        }
    }

    public class DescribeTransferParameters
    {
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }

        public DescribeTransferParameters(String unsignedTxset, String multisigTxset)
        {
            this.UnsignedTxset = unsignedTxset;
            this.MultisigTxset = multisigTxset;
        }
    }

    public class DescribeTransferResult
    {
        [JsonPropertyName("desc")]
        public List<TransferDescription> Desc { get; set; }

        public DescribeTransferResult(List<TransferDescription> desc)
        {
            this.Desc = desc;
        }
    }

    public class SignTransferParameters
    {
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }
        [JsonPropertyName("export_raw")]
        public Boolean ExportRaw { get; set; }
        [JsonPropertyName("get_tx_keys")]
        public Boolean GetTxKeys { get; set; }

        public SignTransferParameters(String unsignedTxset, Boolean exportRaw, Boolean getTxKeys)
        {
            this.UnsignedTxset = unsignedTxset;
            this.ExportRaw = exportRaw;
            this.GetTxKeys = getTxKeys;
        }
    }

    public class SignTransferResult
    {
        [JsonPropertyName("signed_txset")]
        public String SignedTxset { get; set; }
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }
        [JsonPropertyName("tx_raw_list")]
        public List<String> TxRawList { get; set; }
        [JsonPropertyName("tx_key_list")]
        public List<String> TxKeyList { get; set; }

        public SignTransferResult(String signedTxset, List<String> txHashList, List<String> txRawList, List<String> txKeyList)
        {
            this.SignedTxset = signedTxset;
            this.TxHashList = txHashList;
            this.TxRawList = txRawList;
            this.TxKeyList = txKeyList;
        }
    }

    public class SubmitTransferParameters
    {
        [JsonPropertyName("tx_data_hex")]
        public String TxDataHex { get; set; }

        public SubmitTransferParameters(String txDataHex)
        {
            this.TxDataHex = txDataHex;
        }
    }

    public class SubmitTransferResult
    {
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }

        public SubmitTransferResult(List<String> txHashList)
        {
            this.TxHashList = txHashList;
        }
    }

    public class SweepDustParameters
    {
        [JsonPropertyName("get_tx_keys")]
        public Boolean GetTxKeys { get; set; }
        [JsonPropertyName("do_not_relay")]
        public Boolean DoNotRelay { get; set; }
        [JsonPropertyName("get_tx_hex")]
        public Boolean GetTxHex { get; set; }
        [JsonPropertyName("get_tx_metadata")]
        public Boolean GetTxMetadata { get; set; }

        public SweepDustParameters(Boolean getTxKeys, Boolean doNotRelay, Boolean getTxHex, Boolean getTxMetadata)
        {
            this.GetTxKeys = getTxKeys;
            this.DoNotRelay = doNotRelay;
            this.GetTxHex = getTxHex;
            this.GetTxMetadata = getTxMetadata;
        }
    }

    public class SweepDustResult
    {
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }
        [JsonPropertyName("tx_key_list")]
        public List<String> TxKeyList { get; set; }
        [JsonPropertyName("amount_list")]
        public List<Int64> AmountList { get; set; }
        [JsonPropertyName("fee_list")]
        public List<Int64> FeeList { get; set; }
        [JsonPropertyName("weight_list")]
        public List<Int64> WeightList { get; set; }
        [JsonPropertyName("tx_blob_list")]
        public List<String> TxBlobList { get; set; }
        [JsonPropertyName("tx_metadata_list")]
        public List<String> TxMetadataList { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }

        public SweepDustResult(List<String> txHashList, List<String> txKeyList, List<Int64> amountList, List<Int64> feeList, List<Int64> weightList, List<String> txBlobList, List<String> txMetadataList, String multisigTxset, String unsignedTxset)
        {
            this.TxHashList = txHashList;
            this.TxKeyList = txKeyList;
            this.AmountList = amountList;
            this.FeeList = feeList;
            this.WeightList = weightList;
            this.TxBlobList = txBlobList;
            this.TxMetadataList = txMetadataList;
            this.MultisigTxset = multisigTxset;
            this.UnsignedTxset = unsignedTxset;
        }
    }

    public class SweepAllParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public HashSet<Int32> SubaddrIndices { get; set; }
        [JsonPropertyName("subaddr_indices_all")]
        public Boolean SubaddrIndicesAll { get; set; }
        [JsonPropertyName("priority")]
        public Int32 Priority { get; set; }
        [JsonPropertyName("ring_size")]
        public Int64 RingSize { get; set; }
        [JsonPropertyName("outputs")]
        public Int64 Outputs { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("get_tx_keys")]
        public Boolean GetTxKeys { get; set; }
        [JsonPropertyName("below_amount")]
        public Int64 BelowAmount { get; set; }
        [JsonPropertyName("do_not_relay")]
        public Boolean DoNotRelay { get; set; }
        [JsonPropertyName("get_tx_hex")]
        public Boolean GetTxHex { get; set; }
        [JsonPropertyName("get_tx_metadata")]
        public Boolean GetTxMetadata { get; set; }

        public SweepAllParameters(String address, Int32 accountIndex, HashSet<Int32> subaddrIndices, Boolean subaddrIndicesAll, Int32 priority, Int64 ringSize, Int64 outputs, Int64 unlockTime, String paymentId, Boolean getTxKeys, Int64 belowAmount, Boolean doNotRelay, Boolean getTxHex, Boolean getTxMetadata)
        {
            this.Address = address;
            this.AccountIndex = accountIndex;
            this.SubaddrIndices = subaddrIndices;
            this.SubaddrIndicesAll = subaddrIndicesAll;
            this.Priority = priority;
            this.RingSize = ringSize;
            this.Outputs = outputs;
            this.UnlockTime = unlockTime;
            this.PaymentId = paymentId;
            this.GetTxKeys = getTxKeys;
            this.BelowAmount = belowAmount;
            this.DoNotRelay = doNotRelay;
            this.GetTxHex = getTxHex;
            this.GetTxMetadata = getTxMetadata;
        }
    }

    public class SweepAllResult
    {
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }
        [JsonPropertyName("tx_key_list")]
        public List<String> TxKeyList { get; set; }
        [JsonPropertyName("amount_list")]
        public List<Int64> AmountList { get; set; }
        [JsonPropertyName("fee_list")]
        public List<Int64> FeeList { get; set; }
        [JsonPropertyName("weight_list")]
        public List<Int64> WeightList { get; set; }
        [JsonPropertyName("tx_blob_list")]
        public List<String> TxBlobList { get; set; }
        [JsonPropertyName("tx_metadata_list")]
        public List<String> TxMetadataList { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }

        public SweepAllResult(List<String> txHashList, List<String> txKeyList, List<Int64> amountList, List<Int64> feeList, List<Int64> weightList, List<String> txBlobList, List<String> txMetadataList, String multisigTxset, String unsignedTxset)
        {
            this.TxHashList = txHashList;
            this.TxKeyList = txKeyList;
            this.AmountList = amountList;
            this.FeeList = feeList;
            this.WeightList = weightList;
            this.TxBlobList = txBlobList;
            this.TxMetadataList = txMetadataList;
            this.MultisigTxset = multisigTxset;
            this.UnsignedTxset = unsignedTxset;
        }
    }

    public class SweepSingleParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("priority")]
        public Int32 Priority { get; set; }
        [JsonPropertyName("ring_size")]
        public Int64 RingSize { get; set; }
        [JsonPropertyName("outputs")]
        public Int64 Outputs { get; set; }
        [JsonPropertyName("unlock_time")]
        public Int64 UnlockTime { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("get_tx_key")]
        public Boolean GetTxKey { get; set; }
        [JsonPropertyName("key_image")]
        public String KeyImage { get; set; }
        [JsonPropertyName("do_not_relay")]
        public Boolean DoNotRelay { get; set; }
        [JsonPropertyName("get_tx_hex")]
        public Boolean GetTxHex { get; set; }
        [JsonPropertyName("get_tx_metadata")]
        public Boolean GetTxMetadata { get; set; }

        public SweepSingleParameters(String address, Int32 priority, Int64 ringSize, Int64 outputs, Int64 unlockTime, String paymentId, Boolean getTxKey, String keyImage, Boolean doNotRelay, Boolean getTxHex, Boolean getTxMetadata)
        {
            this.Address = address;
            this.Priority = priority;
            this.RingSize = ringSize;
            this.Outputs = outputs;
            this.UnlockTime = unlockTime;
            this.PaymentId = paymentId;
            this.GetTxKey = getTxKey;
            this.KeyImage = keyImage;
            this.DoNotRelay = doNotRelay;
            this.GetTxHex = getTxHex;
            this.GetTxMetadata = getTxMetadata;
        }
    }

    public class SweepSingleResult
    {
        [JsonPropertyName("tx_hash")]
        public String TxHash { get; set; }
        [JsonPropertyName("tx_key")]
        public String TxKey { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("fee")]
        public Int64 Fee { get; set; }
        [JsonPropertyName("weight")]
        public Int64 Weight { get; set; }
        [JsonPropertyName("tx_blob")]
        public String TxBlob { get; set; }
        [JsonPropertyName("tx_metadata")]
        public String TxMetadata { get; set; }
        [JsonPropertyName("multisig_txset")]
        public String MultisigTxset { get; set; }
        [JsonPropertyName("unsigned_txset")]
        public String UnsignedTxset { get; set; }

        public SweepSingleResult(String txHash, String txKey, Int64 amount, Int64 fee, Int64 weight, String txBlob, String txMetadata, String multisigTxset, String unsignedTxset)
        {
            this.TxHash = txHash;
            this.TxKey = txKey;
            this.Amount = amount;
            this.Fee = fee;
            this.Weight = weight;
            this.TxBlob = txBlob;
            this.TxMetadata = txMetadata;
            this.MultisigTxset = multisigTxset;
            this.UnsignedTxset = unsignedTxset;
        }
    }

    public class RelayTxParameters
    {
        [JsonPropertyName("hex")]
        public String Hex { get; set; }

        public RelayTxParameters(String hex)
        {
            this.Hex = hex;
        }
    }

    public class RelayTxResult
    {
        [JsonPropertyName("tx_hash")]
        public String TxHash { get; set; }

        public RelayTxResult(String txHash)
        {
            this.TxHash = txHash;
        }
    }

    public class StoreParameters
    {
        public StoreParameters()
        {
        }
    }

    public class StoreResult
    {
        public StoreResult()
        {
        }
    }

    public class GetPaymentsParameters
    {
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }

        public GetPaymentsParameters(String paymentId)
        {
            this.PaymentId = paymentId;
        }
    }

    public class GetPaymentsResult
    {
        [JsonPropertyName("payments")]
        public List<PaymentDetails> Payments { get; set; }

        public GetPaymentsResult(List<PaymentDetails> payments)
        {
            this.Payments = payments;
        }
    }

    public class GetBulkPaymentsParameters
    {
        [JsonPropertyName("payment_ids")]
        public List<String> PaymentIds { get; set; }
        [JsonPropertyName("min_block_height")]
        public Int64 MinBlockHeight { get; set; }

        public GetBulkPaymentsParameters(List<String> paymentIds, Int64 minBlockHeight)
        {
            this.PaymentIds = paymentIds;
            this.MinBlockHeight = minBlockHeight;
        }
    }

    public class GetBulkPaymentsResult
    {
        [JsonPropertyName("payments")]
        public List<PaymentDetails> Payments { get; set; }

        public GetBulkPaymentsResult(List<PaymentDetails> payments)
        {
            this.Payments = payments;
        }
    }

    public class IncomingTransfersParameters
    {
        [JsonPropertyName("transfer_type")]
        public String TransferType { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public HashSet<Int32> SubaddrIndices { get; set; }

        public IncomingTransfersParameters(String transferType, Int32 accountIndex, HashSet<Int32> subaddrIndices)
        {
            this.TransferType = transferType;
            this.AccountIndex = accountIndex;
            this.SubaddrIndices = subaddrIndices;
        }
    }

    public class IncomingTransfersResult
    {
        [JsonPropertyName("transfers")]
        public List<TransferDetails> Transfers { get; set; }

        public IncomingTransfersResult(List<TransferDetails> transfers)
        {
            this.Transfers = transfers;
        }
    }

    public class QueryKeyParameters
    {
        [JsonPropertyName("key_type")]
        public String KeyType { get; set; }

        public QueryKeyParameters(String keyType)
        {
            this.KeyType = keyType;
        }
    }

    public class QueryKeyResult
    {
        [JsonPropertyName("key")]
        public String Key { get; set; }

        public QueryKeyResult(String key)
        {
            this.Key = key;
        }
    }

    public class MakeIntegratedAddressParameters
    {
        [JsonPropertyName("standard_address")]
        public String StandardAddress { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }

        public MakeIntegratedAddressParameters(String standardAddress, String paymentId)
        {
            this.StandardAddress = standardAddress;
            this.PaymentId = paymentId;
        }
    }

    public class MakeIntegratedAddressResult
    {
        [JsonPropertyName("integrated_address")]
        public String IntegratedAddress { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }

        public MakeIntegratedAddressResult(String integratedAddress, String paymentId)
        {
            this.IntegratedAddress = integratedAddress;
            this.PaymentId = paymentId;
        }
    }

    public class SplitIntegratedAddressParameters
    {
        [JsonPropertyName("integrated_address")]
        public String IntegratedAddress { get; set; }

        public SplitIntegratedAddressParameters(String integratedAddress)
        {
            this.IntegratedAddress = integratedAddress;
        }
    }

    public class SplitIntegratedAddressResult
    {
        [JsonPropertyName("standard_address")]
        public String StandardAddress { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("is_subaddress")]
        public Boolean IsSubaddress { get; set; }

        public SplitIntegratedAddressResult(String standardAddress, String paymentId, Boolean isSubaddress)
        {
            this.StandardAddress = standardAddress;
            this.PaymentId = paymentId;
            this.IsSubaddress = isSubaddress;
        }
    }

    public class StopWalletParameters
    {
        public StopWalletParameters()
        {
        }
    }

    public class StopWalletResult
    {
        public StopWalletResult()
        {
        }
    }

    public class RescanBlockchainParameters
    {
        [JsonPropertyName("hard")]
        public Boolean Hard { get; set; }

        public RescanBlockchainParameters(Boolean hard)
        {
            this.Hard = hard;
        }
    }

    public class RescanBlockchainResult
    {
        public RescanBlockchainResult()
        {
        }
    }

    public class SetTxNotesParameters
    {
        [JsonPropertyName("txids")]
        public List<String> Txids { get; set; }
        [JsonPropertyName("notes")]
        public List<String> Notes { get; set; }

        public SetTxNotesParameters(List<String> txids, List<String> notes)
        {
            this.Txids = txids;
            this.Notes = notes;
        }
    }

    public class SetTxNotesResult
    {
        public SetTxNotesResult()
        {
        }
    }

    public class GetTxNotesParameters
    {
        [JsonPropertyName("txids")]
        public List<String> Txids { get; set; }

        public GetTxNotesParameters(List<String> txids)
        {
            this.Txids = txids;
        }
    }

    public class GetTxNotesResult
    {
        [JsonPropertyName("notes")]
        public List<String> Notes { get; set; }

        public GetTxNotesResult(List<String> notes)
        {
            this.Notes = notes;
        }
    }

    public class SetAttributeParameters
    {
        [JsonPropertyName("key")]
        public String Key { get; set; }
        [JsonPropertyName("value")]
        public String Value { get; set; }

        public SetAttributeParameters(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class SetAttributeResult
    {
        public SetAttributeResult()
        {
        }
    }

    public class GetAttributeParameters
    {
        [JsonPropertyName("key")]
        public String Key { get; set; }

        public GetAttributeParameters(String key)
        {
            this.Key = key;
        }
    }

    public class GetAttributeResult
    {
        [JsonPropertyName("value")]
        public String Value { get; set; }

        public GetAttributeResult(String value)
        {
            this.Value = value;
        }
    }

    public class GetTxKeyParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }

        public GetTxKeyParameters(String txid)
        {
            this.Txid = txid;
        }
    }

    public class GetTxKeyResult
    {
        [JsonPropertyName("tx_key")]
        public String TxKey { get; set; }

        public GetTxKeyResult(String txKey)
        {
            this.TxKey = txKey;
        }
    }

    public class CheckTxKeyParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("tx_key")]
        public String TxKey { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public CheckTxKeyParameters(String txid, String txKey, String address)
        {
            this.Txid = txid;
            this.TxKey = txKey;
            this.Address = address;
        }
    }

    public class CheckTxKeyResult
    {
        [JsonPropertyName("received")]
        public Int64 Received { get; set; }
        [JsonPropertyName("in_pool")]
        public Boolean InPool { get; set; }
        [JsonPropertyName("confirmations")]
        public Int64 Confirmations { get; set; }

        public CheckTxKeyResult(Int64 received, Boolean inPool, Int64 confirmations)
        {
            this.Received = received;
            this.InPool = inPool;
            this.Confirmations = confirmations;
        }
    }

    public class GetTxProofParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }

        public GetTxProofParameters(String txid, String address, String message)
        {
            this.Txid = txid;
            this.Address = address;
            this.Message = message;
        }
    }

    public class GetTxProofResult
    {
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public GetTxProofResult(String signature)
        {
            this.Signature = signature;
        }
    }

    public class CheckTxProofParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public CheckTxProofParameters(String txid, String address, String message, String signature)
        {
            this.Txid = txid;
            this.Address = address;
            this.Message = message;
            this.Signature = signature;
        }
    }

    public class CheckTxProofResult
    {
        [JsonPropertyName("good")]
        public Boolean Good { get; set; }
        [JsonPropertyName("received")]
        public Int64 Received { get; set; }
        [JsonPropertyName("in_pool")]
        public Boolean InPool { get; set; }
        [JsonPropertyName("confirmations")]
        public Int64 Confirmations { get; set; }

        public CheckTxProofResult(Boolean good, Int64 received, Boolean inPool, Int64 confirmations)
        {
            this.Good = good;
            this.Received = received;
            this.InPool = inPool;
            this.Confirmations = confirmations;
        }
    }

    public class GetSpendProofParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }

        public GetSpendProofParameters(String txid, String message)
        {
            this.Txid = txid;
            this.Message = message;
        }
    }

    public class GetSpendProofResult
    {
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public GetSpendProofResult(String signature)
        {
            this.Signature = signature;
        }
    }

    public class CheckSpendProofParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public CheckSpendProofParameters(String txid, String message, String signature)
        {
            this.Txid = txid;
            this.Message = message;
            this.Signature = signature;
        }
    }

    public class CheckSpendProofResult
    {
        [JsonPropertyName("good")]
        public Boolean Good { get; set; }

        public CheckSpendProofResult(Boolean good)
        {
            this.Good = good;
        }
    }

    public class GetReserveProofParameters
    {
        [JsonPropertyName("all")]
        public Boolean All { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }

        public GetReserveProofParameters(Boolean all, Int32 accountIndex, Int64 amount, String message)
        {
            this.All = all;
            this.AccountIndex = accountIndex;
            this.Amount = amount;
            this.Message = message;
        }
    }

    public class GetReserveProofResult
    {
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public GetReserveProofResult(String signature)
        {
            this.Signature = signature;
        }
    }

    public class CheckReserveProofParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("message")]
        public String Message { get; set; }
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public CheckReserveProofParameters(String address, String message, String signature)
        {
            this.Address = address;
            this.Message = message;
            this.Signature = signature;
        }
    }

    public class CheckReserveProofResult
    {
        [JsonPropertyName("good")]
        public Boolean Good { get; set; }
        [JsonPropertyName("total")]
        public Int64 Total { get; set; }
        [JsonPropertyName("spent")]
        public Int64 Spent { get; set; }

        public CheckReserveProofResult(Boolean good, Int64 total, Int64 spent)
        {
            this.Good = good;
            this.Total = total;
            this.Spent = spent;
        }
    }

    public class GetTransfersParameters
    {
        [JsonPropertyName("in")]
        public Boolean In { get; set; }
        [JsonPropertyName("out")]
        public Boolean Out { get; set; }
        [JsonPropertyName("pending")]
        public Boolean Pending { get; set; }
        [JsonPropertyName("failed")]
        public Boolean Failed { get; set; }
        [JsonPropertyName("pool")]
        public Boolean Pool { get; set; }
        [JsonPropertyName("filter_by_height")]
        public Boolean FilterByHeight { get; set; }
        [JsonPropertyName("min_height")]
        public Int64 MinHeight { get; set; }
        [JsonPropertyName("max_height")]
        public Int64 MaxHeight { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("subaddr_indices")]
        public HashSet<Int32> SubaddrIndices { get; set; }
        [JsonPropertyName("all_accounts")]
        public Boolean AllAccounts { get; set; }

        public GetTransfersParameters(Boolean @in, Boolean @out, Boolean pending, Boolean failed, Boolean pool, Boolean filterByHeight, Int64 minHeight, Int64 maxHeight, Int32 accountIndex, HashSet<Int32> subaddrIndices, Boolean allAccounts)
        {
            this.In = @in;
            this.Out = @out;
            this.Pending = pending;
            this.Failed = failed;
            this.Pool = pool;
            this.FilterByHeight = filterByHeight;
            this.MinHeight = minHeight;
            this.MaxHeight = maxHeight;
            this.AccountIndex = accountIndex;
            this.SubaddrIndices = subaddrIndices;
            this.AllAccounts = allAccounts;
        }
    }

    public class GetTransfersResult
    {
        [JsonPropertyName("in")]
        public List<TransferEntry> In { get; set; }
        [JsonPropertyName("out")]
        public List<TransferEntry> Out { get; set; }
        [JsonPropertyName("pending")]
        public List<TransferEntry> Pending { get; set; }
        [JsonPropertyName("failed")]
        public List<TransferEntry> Failed { get; set; }
        [JsonPropertyName("pool")]
        public List<TransferEntry> Pool { get; set; }

        public GetTransfersResult(List<TransferEntry> @in, List<TransferEntry> @out, List<TransferEntry> pending, List<TransferEntry> failed, List<TransferEntry> pool)
        {
            this.In = @in;
            this.Out = @out;
            this.Pending = pending;
            this.Failed = failed;
            this.Pool = pool;
        }
    }

    public class GetTransferByTxidParameters
    {
        [JsonPropertyName("txid")]
        public String Txid { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }

        public GetTransferByTxidParameters(String txid, Int32 accountIndex)
        {
            this.Txid = txid;
            this.AccountIndex = accountIndex;
        }
    }

    public class GetTransferByTxidResult
    {
        [JsonPropertyName("transfer")]
        public TransferEntry Transfer { get; set; }
        [JsonPropertyName("transfers")]
        public List<TransferEntry> Transfers { get; set; }

        public GetTransferByTxidResult(TransferEntry transfer, List<TransferEntry> transfers)
        {
            this.Transfer = transfer;
            this.Transfers = transfers;
        }
    }

    public class SignParameters
    {
        [JsonPropertyName("data")]
        public String Data { get; set; }
        [JsonPropertyName("account_index")]
        public Int32 AccountIndex { get; set; }
        [JsonPropertyName("address_index")]
        public Int32 AddressIndex { get; set; }
        [JsonPropertyName("signature_type")]
        public String SignatureType { get; set; }

        public SignParameters(String data, Int32 accountIndex, Int32 addressIndex, String signatureType)
        {
            this.Data = data;
            this.AccountIndex = accountIndex;
            this.AddressIndex = addressIndex;
            this.SignatureType = signatureType;
        }
    }

    public class SignResult
    {
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public SignResult(String signature)
        {
            this.Signature = signature;
        }
    }

    public class VerifyParameters
    {
        [JsonPropertyName("data")]
        public String Data { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("signature")]
        public String Signature { get; set; }

        public VerifyParameters(String data, String address, String signature)
        {
            this.Data = data;
            this.Address = address;
            this.Signature = signature;
        }
    }

    public class VerifyResult
    {
        [JsonPropertyName("good")]
        public Boolean Good { get; set; }
        [JsonPropertyName("version")]
        public UInt32 Version { get; set; }
        [JsonPropertyName("old")]
        public Boolean Old { get; set; }
        [JsonPropertyName("signature_type")]
        public String SignatureType { get; set; }

        public VerifyResult(Boolean good, UInt32 version, Boolean old, String signatureType)
        {
            this.Good = good;
            this.Version = version;
            this.Old = old;
            this.SignatureType = signatureType;
        }
    }

    public class ExportOutputsParameters
    {
        [JsonPropertyName("all")]
        public Boolean All { get; set; }

        public ExportOutputsParameters(Boolean all)
        {
            this.All = all;
        }
    }

    public class ExportOutputsResult
    {
        [JsonPropertyName("outputs_data_hex")]
        public String OutputsDataHex { get; set; }

        public ExportOutputsResult(String outputsDataHex)
        {
            this.OutputsDataHex = outputsDataHex;
        }
    }

    public class ImportOutputsParameters
    {
        [JsonPropertyName("outputs_data_hex")]
        public String OutputsDataHex { get; set; }

        public ImportOutputsParameters(String outputsDataHex)
        {
            this.OutputsDataHex = outputsDataHex;
        }
    }

    public class ImportOutputsResult
    {
        [JsonPropertyName("num_imported")]
        public Int64 NumImported { get; set; }

        public ImportOutputsResult(Int64 numImported)
        {
            this.NumImported = numImported;
        }
    }

    public class ExportKeyImagesParameters
    {
        [JsonPropertyName("all")]
        public Boolean All { get; set; }

        public ExportKeyImagesParameters(Boolean all)
        {
            this.All = all;
        }
    }

    public class ExportKeyImagesResult
    {
        [JsonPropertyName("offset")]
        public Int32 Offset { get; set; }
        [JsonPropertyName("signed_key_images")]
        public List<SignedKeyImage> SignedKeyImages { get; set; }

        public ExportKeyImagesResult(Int32 offset, List<SignedKeyImage> signedKeyImages)
        {
            this.Offset = offset;
            this.SignedKeyImages = signedKeyImages;
        }
    }

    public class ImportKeyImagesParameters
    {
        [JsonPropertyName("offset")]
        public Int32 Offset { get; set; }
        [JsonPropertyName("signed_key_images")]
        public List<SignedKeyImage> SignedKeyImages { get; set; }

        public ImportKeyImagesParameters(Int32 offset, List<SignedKeyImage> signedKeyImages)
        {
            this.Offset = offset;
            this.SignedKeyImages = signedKeyImages;
        }
    }

    public class ImportKeyImagesResult
    {
        [JsonPropertyName("height")]
        public Int64 Height { get; set; }
        [JsonPropertyName("spent")]
        public Int64 Spent { get; set; }
        [JsonPropertyName("unspent")]
        public Int64 Unspent { get; set; }

        public ImportKeyImagesResult(Int64 height, Int64 spent, Int64 unspent)
        {
            this.Height = height;
            this.Spent = spent;
            this.Unspent = unspent;
        }
    }

    public class MakeUriParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("payment_id")]
        public String PaymentId { get; set; }
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }
        [JsonPropertyName("tx_description")]
        public String TxDescription { get; set; }
        [JsonPropertyName("recipient_name")]
        public String RecipientName { get; set; }

        public MakeUriParameters(String address, String paymentId, Int64 amount, String txDescription, String recipientName)
        {
            this.Address = address;
            this.PaymentId = paymentId;
            this.Amount = amount;
            this.TxDescription = txDescription;
            this.RecipientName = recipientName;
        }
    }

    public class MakeUriResult
    {
        [JsonPropertyName("uri")]
        public String Uri { get; set; }

        public MakeUriResult(String uri)
        {
            this.Uri = uri;
        }
    }

    public class ParseUriParameters
    {
        [JsonPropertyName("uri")]
        public String Uri { get; set; }

        public ParseUriParameters(String uri)
        {
            this.Uri = uri;
        }
    }

    public class ParseUriResult
    {
        [JsonPropertyName("uri")]
        public UriSpec Uri { get; set; }
        [JsonPropertyName("unknown_parameters")]
        public List<String> UnknownParameters { get; set; }

        public ParseUriResult(UriSpec uri, List<String> unknownParameters)
        {
            this.Uri = uri;
            this.UnknownParameters = unknownParameters;
        }
    }

    public class AddAddressBookEntryParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }

        public AddAddressBookEntryParameters(String address, String description)
        {
            this.Address = address;
            this.Description = description;
        }
    }

    public class AddAddressBookEntryResult
    {
        [JsonPropertyName("index")]
        public Int64 Index { get; set; }

        public AddAddressBookEntryResult(Int64 index)
        {
            this.Index = index;
        }
    }

    public class EditAddressBookEntryParameters
    {
        [JsonPropertyName("index")]
        public Int64 Index { get; set; }
        [JsonPropertyName("set_address")]
        public Boolean SetAddress { get; set; }
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("set_description")]
        public Boolean SetDescription { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }

        public EditAddressBookEntryParameters(Int64 index, Boolean setAddress, String address, Boolean setDescription, String description)
        {
            this.Index = index;
            this.SetAddress = setAddress;
            this.Address = address;
            this.SetDescription = setDescription;
            this.Description = description;
        }
    }

    public class EditAddressBookEntryResult
    {
        public EditAddressBookEntryResult()
        {
        }
    }

    public class GetAddressBookEntryParameters
    {
        [JsonPropertyName("entries")]
        public List<Int64> Entries { get; set; }

        public GetAddressBookEntryParameters(List<Int64> entries)
        {
            this.Entries = entries;
        }
    }

    public class GetAddressBookEntryResult
    {
        [JsonPropertyName("entries")]
        public List<Entry> Entries { get; set; }

        public GetAddressBookEntryResult(List<Entry> entries)
        {
            this.Entries = entries;
        }
    }

    public class DeleteAddressBookEntryParameters
    {
        [JsonPropertyName("index")]
        public Int64 Index { get; set; }

        public DeleteAddressBookEntryParameters(Int64 index)
        {
            this.Index = index;
        }
    }

    public class DeleteAddressBookEntryResult
    {
        public DeleteAddressBookEntryResult()
        {
        }
    }

    public class RescanSpentParameters
    {
        public RescanSpentParameters()
        {
        }
    }

    public class RescanSpentResult
    {
        public RescanSpentResult()
        {
        }
    }

    public class RefreshParameters
    {
        [JsonPropertyName("start_height")]
        public Int64 StartHeight { get; set; }

        public RefreshParameters(Int64 startHeight)
        {
            this.StartHeight = startHeight;
        }
    }

    public class RefreshResult
    {
        [JsonPropertyName("blocks_fetched")]
        public Int64 BlocksFetched { get; set; }
        [JsonPropertyName("received_money")]
        public Boolean ReceivedMoney { get; set; }

        public RefreshResult(Int64 blocksFetched, Boolean receivedMoney)
        {
            this.BlocksFetched = blocksFetched;
            this.ReceivedMoney = receivedMoney;
        }
    }

    public class AutoRefreshParameters
    {
        [JsonPropertyName("enable")]
        public Boolean Enable { get; set; }
        [JsonPropertyName("period")]
        public Int32 Period { get; set; }

        public AutoRefreshParameters(Boolean enable, Int32 period)
        {
            this.Enable = enable;
            this.Period = period;
        }
    }

    public class AutoRefreshResult
    {
        public AutoRefreshResult()
        {
        }
    }

    public class ScanTxParameters
    {
        [JsonPropertyName("txids")]
        public List<String> Txids { get; set; }

        public ScanTxParameters(List<String> txids)
        {
            this.Txids = txids;
        }
    }

    public class ScanTxResult
    {
        public ScanTxResult()
        {
        }
    }

    public class StartMiningParameters
    {
        [JsonPropertyName("threads_count")]
        public Int64 ThreadsCount { get; set; }
        [JsonPropertyName("do_background_mining")]
        public Boolean DoBackgroundMining { get; set; }
        [JsonPropertyName("ignore_battery")]
        public Boolean IgnoreBattery { get; set; }

        public StartMiningParameters(Int64 threadsCount, Boolean doBackgroundMining, Boolean ignoreBattery)
        {
            this.ThreadsCount = threadsCount;
            this.DoBackgroundMining = doBackgroundMining;
            this.IgnoreBattery = ignoreBattery;
        }
    }

    public class StartMiningResult
    {
        public StartMiningResult()
        {
        }
    }

    public class StopMiningParameters
    {
        public StopMiningParameters()
        {
        }
    }

    public class StopMiningResult
    {
        public StopMiningResult()
        {
        }
    }

    public class GetLanguagesParameters
    {
        public GetLanguagesParameters()
        {
        }
    }

    public class GetLanguagesResult
    {
        [JsonPropertyName("languages")]
        public List<String> Languages { get; set; }
        [JsonPropertyName("languages_local")]
        public List<String> LanguagesLocal { get; set; }

        public GetLanguagesResult(List<String> languages, List<String> languagesLocal)
        {
            this.Languages = languages;
            this.LanguagesLocal = languagesLocal;
        }
    }

    public class CreateWalletParameters
    {
        [JsonPropertyName("filename")]
        public String Filename { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("language")]
        public String Language { get; set; }

        public CreateWalletParameters(String filename, String password, String language)
        {
            this.Filename = filename;
            this.Password = password;
            this.Language = language;
        }
    }

    public class CreateWalletResult
    {
        public CreateWalletResult()
        {
        }
    }

    public class OpenWalletParameters
    {
        [JsonPropertyName("filename")]
        public String Filename { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("autosave_current")]
        public Boolean AutosaveCurrent { get; set; }

        public OpenWalletParameters(String filename, String password, Boolean autosaveCurrent)
        {
            this.Filename = filename;
            this.Password = password;
            this.AutosaveCurrent = autosaveCurrent;
        }
    }

    public class OpenWalletResult
    {
        public OpenWalletResult()
        {
        }
    }

    public class CloseWalletParameters
    {
        [JsonPropertyName("autosave_current")]
        public Boolean AutosaveCurrent { get; set; }

        public CloseWalletParameters(Boolean autosaveCurrent)
        {
            this.AutosaveCurrent = autosaveCurrent;
        }
    }

    public class CloseWalletResult
    {
        public CloseWalletResult()
        {
        }
    }

    public class ChangeWalletPasswordParameters
    {
        [JsonPropertyName("old_password")]
        public String OldPassword { get; set; }
        [JsonPropertyName("new_password")]
        public String NewPassword { get; set; }

        public ChangeWalletPasswordParameters(String oldPassword, String newPassword)
        {
            this.OldPassword = oldPassword;
            this.NewPassword = newPassword;
        }
    }

    public class ChangeWalletPasswordResult
    {
        public ChangeWalletPasswordResult()
        {
        }
    }

    public class GenerateFromKeysParameters
    {
        public GenerateFromKeysParameters()
        {
        }
    }

    public class GenerateFromKeysResult
    {
        public GenerateFromKeysResult()
        {
        }
    }

    public class RestoreDeterministicWalletParameters
    {
        [JsonPropertyName("restore_height")]
        public Int64 RestoreHeight { get; set; }
        [JsonPropertyName("filename")]
        public String Filename { get; set; }
        [JsonPropertyName("seed")]
        public String Seed { get; set; }
        [JsonPropertyName("seed_offset")]
        public String SeedOffset { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("language")]
        public String Language { get; set; }
        [JsonPropertyName("autosave_current")]
        public Boolean AutosaveCurrent { get; set; }

        public RestoreDeterministicWalletParameters(Int64 restoreHeight, String filename, String seed, String seedOffset, String password, String language, Boolean autosaveCurrent)
        {
            this.RestoreHeight = restoreHeight;
            this.Filename = filename;
            this.Seed = seed;
            this.SeedOffset = seedOffset;
            this.Password = password;
            this.Language = language;
            this.AutosaveCurrent = autosaveCurrent;
        }
    }

    public class RestoreDeterministicWalletResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("seed")]
        public String Seed { get; set; }
        [JsonPropertyName("info")]
        public String Info { get; set; }
        [JsonPropertyName("was_deprecated")]
        public Boolean WasDeprecated { get; set; }

        public RestoreDeterministicWalletResult(String address, String seed, String info, Boolean wasDeprecated)
        {
            this.Address = address;
            this.Seed = seed;
            this.Info = info;
            this.WasDeprecated = wasDeprecated;
        }
    }

    public class IsMultisigParameters
    {
        public IsMultisigParameters()
        {
        }
    }

    public class IsMultisigResult
    {
        [JsonPropertyName("multisig")]
        public Boolean Multisig { get; set; }
        [JsonPropertyName("ready")]
        public Boolean Ready { get; set; }
        [JsonPropertyName("threshold")]
        public Int32 Threshold { get; set; }
        [JsonPropertyName("total")]
        public Int32 Total { get; set; }

        public IsMultisigResult(Boolean multisig, Boolean ready, Int32 threshold, Int32 total)
        {
            this.Multisig = multisig;
            this.Ready = ready;
            this.Threshold = threshold;
            this.Total = total;
        }
    }

    public class PrepareMultisigParameters
    {
        public PrepareMultisigParameters()
        {
        }
    }

    public class PrepareMultisigResult
    {
        [JsonPropertyName("multisig_info")]
        public String MultisigInfo { get; set; }

        public PrepareMultisigResult(String multisigInfo)
        {
            this.MultisigInfo = multisigInfo;
        }
    }

    public class MakeMultisigParameters
    {
        [JsonPropertyName("multisig_info")]
        public List<String> MultisigInfo { get; set; }
        [JsonPropertyName("threshold")]
        public Int32 Threshold { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }

        public MakeMultisigParameters(List<String> multisigInfo, Int32 threshold, String password)
        {
            this.MultisigInfo = multisigInfo;
            this.Threshold = threshold;
            this.Password = password;
        }
    }

    public class MakeMultisigResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("multisig_info")]
        public String MultisigInfo { get; set; }

        public MakeMultisigResult(String address, String multisigInfo)
        {
            this.Address = address;
            this.MultisigInfo = multisigInfo;
        }
    }

    public class ExportMultisigParameters
    {
        public ExportMultisigParameters()
        {
        }
    }

    public class ExportMultisigResult
    {
        [JsonPropertyName("info")]
        public String Info { get; set; }

        public ExportMultisigResult(String info)
        {
            this.Info = info;
        }
    }

    public class ImportMultisigParameters
    {
        [JsonPropertyName("info")]
        public List<String> Info { get; set; }

        public ImportMultisigParameters(List<String> info)
        {
            this.Info = info;
        }
    }

    public class ImportMultisigResult
    {
        [JsonPropertyName("n_outputs")]
        public Int64 NOutputs { get; set; }

        public ImportMultisigResult(Int64 nOutputs)
        {
            this.NOutputs = nOutputs;
        }
    }

    public class FinalizeMultisigParameters
    {
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("multisig_info")]
        public List<String> MultisigInfo { get; set; }

        public FinalizeMultisigParameters(String password, List<String> multisigInfo)
        {
            this.Password = password;
            this.MultisigInfo = multisigInfo;
        }
    }

    public class FinalizeMultisigResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }

        public FinalizeMultisigResult(String address)
        {
            this.Address = address;
        }
    }

    public class ExchangeMultisigKeysParameters
    {
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("multisig_info")]
        public List<String> MultisigInfo { get; set; }

        public ExchangeMultisigKeysParameters(String password, List<String> multisigInfo)
        {
            this.Password = password;
            this.MultisigInfo = multisigInfo;
        }
    }

    public class ExchangeMultisigKeysResult
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("multisig_info")]
        public String MultisigInfo { get; set; }

        public ExchangeMultisigKeysResult(String address, String multisigInfo)
        {
            this.Address = address;
            this.MultisigInfo = multisigInfo;
        }
    }

    public class SignMultisigParameters
    {
        [JsonPropertyName("tx_data_hex")]
        public String TxDataHex { get; set; }

        public SignMultisigParameters(String txDataHex)
        {
            this.TxDataHex = txDataHex;
        }
    }

    public class SignMultisigResult
    {
        [JsonPropertyName("tx_data_hex")]
        public String TxDataHex { get; set; }
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }

        public SignMultisigResult(String txDataHex, List<String> txHashList)
        {
            this.TxDataHex = txDataHex;
            this.TxHashList = txHashList;
        }
    }

    public class SubmitMultisigParameters
    {
        [JsonPropertyName("tx_data_hex")]
        public String TxDataHex { get; set; }

        public SubmitMultisigParameters(String txDataHex)
        {
            this.TxDataHex = txDataHex;
        }
    }

    public class SubmitMultisigResult
    {
        [JsonPropertyName("tx_hash_list")]
        public List<String> TxHashList { get; set; }

        public SubmitMultisigResult(List<String> txHashList)
        {
            this.TxHashList = txHashList;
        }
    }

    public class GetVersionParameters
    {
        public GetVersionParameters()
        {
        }
    }

    public class GetVersionResult
    {
        [JsonPropertyName("version")]
        public Int32 Version { get; set; }
        [JsonPropertyName("release")]
        public Boolean Release { get; set; }

        public GetVersionResult(Int32 version, Boolean release)
        {
            this.Version = version;
            this.Release = release;
        }
    }

    public class ValidateAddressParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("any_net_type")]
        public Boolean AnyNetType { get; set; }
        [JsonPropertyName("allow_openalias")]
        public Boolean AllowOpenalias { get; set; }

        public ValidateAddressParameters(String address, Boolean anyNetType, Boolean allowOpenalias)
        {
            this.Address = address;
            this.AnyNetType = anyNetType;
            this.AllowOpenalias = allowOpenalias;
        }
    }

    public class ValidateAddressResult
    {
        [JsonPropertyName("valid")]
        public Boolean Valid { get; set; }
        [JsonPropertyName("integrated")]
        public Boolean Integrated { get; set; }
        [JsonPropertyName("subaddress")]
        public Boolean Subaddress { get; set; }
        [JsonPropertyName("nettype")]
        public String Nettype { get; set; }
        [JsonPropertyName("openalias_address")]
        public String OpenaliasAddress { get; set; }

        public ValidateAddressResult(Boolean valid, Boolean integrated, Boolean subaddress, String nettype, String openaliasAddress)
        {
            this.Valid = valid;
            this.Integrated = integrated;
            this.Subaddress = subaddress;
            this.Nettype = nettype;
            this.OpenaliasAddress = openaliasAddress;
        }
    }

    public class SetDaemonParameters
    {
        [JsonPropertyName("address")]
        public String Address { get; set; }
        [JsonPropertyName("trusted")]
        public Boolean Trusted { get; set; }
        [JsonPropertyName("ssl_support")]
        public String SslSupport { get; set; }
        [JsonPropertyName("ssl_private_key_path")]
        public String SslPrivateKeyPath { get; set; }
        [JsonPropertyName("ssl_certificate_path")]
        public String SslCertificatePath { get; set; }
        [JsonPropertyName("ssl_ca_file")]
        public String SslCaFile { get; set; }
        [JsonPropertyName("ssl_allowed_fingerprints")]
        public List<String> SslAllowedFingerprints { get; set; }
        [JsonPropertyName("ssl_allow_any_cert")]
        public Boolean SslAllowAnyCert { get; set; }

        public SetDaemonParameters(String address, Boolean trusted, String sslSupport, String sslPrivateKeyPath, String sslCertificatePath, String sslCaFile, List<String> sslAllowedFingerprints, Boolean sslAllowAnyCert)
        {
            this.Address = address;
            this.Trusted = trusted;
            this.SslSupport = sslSupport;
            this.SslPrivateKeyPath = sslPrivateKeyPath;
            this.SslCertificatePath = sslCertificatePath;
            this.SslCaFile = sslCaFile;
            this.SslAllowedFingerprints = sslAllowedFingerprints;
            this.SslAllowAnyCert = sslAllowAnyCert;
        }
    }

    public class SetDaemonResult
    {
        public SetDaemonResult()
        {
        }
    }

    public class SetLogLevelParameters
    {
        [JsonPropertyName("level")]
        public Byte Level { get; set; }

        public SetLogLevelParameters(Byte level)
        {
            this.Level = level;
        }
    }

    public class SetLogLevelResult
    {
        public SetLogLevelResult()
        {
        }
    }

    public class SetLogCategoriesParameters
    {
        [JsonPropertyName("categories")]
        public String Categories { get; set; }

        public SetLogCategoriesParameters(String categories)
        {
            this.Categories = categories;
        }
    }

    public class SetLogCategoriesResult
    {
        [JsonPropertyName("categories")]
        public String Categories { get; set; }

        public SetLogCategoriesResult(String categories)
        {
            this.Categories = categories;
        }
    }

    public class EstimateTxSizeAndWeightParameters
    {
        [JsonPropertyName("n_inputs")]
        public Int32 NInputs { get; set; }
        [JsonPropertyName("n_outputs")]
        public Int32 NOutputs { get; set; }
        [JsonPropertyName("ring_size")]
        public Int32 RingSize { get; set; }
        [JsonPropertyName("rct")]
        public Boolean Rct { get; set; }

        public EstimateTxSizeAndWeightParameters(Int32 nInputs, Int32 nOutputs, Int32 ringSize, Boolean rct)
        {
            this.NInputs = nInputs;
            this.NOutputs = nOutputs;
            this.RingSize = ringSize;
            this.Rct = rct;
        }
    }

    public class EstimateTxSizeAndWeightResult
    {
        [JsonPropertyName("size")]
        public Int64 Size { get; set; }
        [JsonPropertyName("weight")]
        public Int64 Weight { get; set; }

        public EstimateTxSizeAndWeightResult(Int64 size, Int64 weight)
        {
            this.Size = size;
            this.Weight = weight;
        }
    }
}
