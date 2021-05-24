namespace MoneroPay.WalletRpc.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class PerSubaddressInfo
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("AddressIndex")]
        Int32 AddressIndex[JsonProperty("Address")]
        String Address[JsonProperty("Balance")]
        Int64 Balance[JsonProperty("UnlockedBalance")]
        Int64 UnlockedBalance[JsonProperty("Label")]
        String Label[JsonProperty("NumUnspentOutputs")]
        Int64 NumUnspentOutputs[JsonProperty("BlocksToUnlock")]
        Int64 BlocksToUnlock[JsonProperty("TimeToUnlock")]
        Int64 TimeToUnlock
    }

    public class AddressInfo
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Label")]
        String Label[JsonProperty("AddressIndex")]
        Int32 AddressIndex[JsonProperty("Used")]
        Boolean Used
    }

    public class SubaddressAccountInfo
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("BaseAddress")]
        String BaseAddress[JsonProperty("Balance")]
        Int64 Balance[JsonProperty("UnlockedBalance")]
        Int64 UnlockedBalance[JsonProperty("Label")]
        String Label[JsonProperty("Tag")]
        String Tag
    }

    public class AccountTagInfo
    {
        [JsonProperty("Tag")]
        String Tag[JsonProperty("Label")]
        String Label[JsonProperty("Accounts")]
        Int32 Accounts
    }

    public class TransferDestination
    {
        [JsonProperty("Amount")]
        Int64 Amount[JsonProperty("Address")]
        String Address
    }

    public class KeyList
    {
        [JsonProperty("Keys")]
        String Keys
    }

    public class Recipient
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Amount")]
        Int64 Amount
    }

    public class TransferDescription
    {
        [JsonProperty("AmountIn")]
        Int64 AmountIn[JsonProperty("AmountOut")]
        Int64 AmountOut[JsonProperty("RingSize")]
        Int32 RingSize[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("Recipients")]
        List<Recipient> Recipients[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("ChangeAmount")]
        Int64 ChangeAmount[JsonProperty("ChangeAddress")]
        String ChangeAddress[JsonProperty("Fee")]
        Int64 Fee[JsonProperty("DummyOutputs")]
        Int32 DummyOutputs[JsonProperty("Extra")]
        String Extra
    }

    public class KeyList
    {
        [JsonProperty("Keys")]
        String Keys
    }

    public class KeyList
    {
        [JsonProperty("Keys")]
        String Keys
    }

    public class PaymentDetails
    {
        [JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("TxHash")]
        String TxHash[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("BlockHeight")]
        Int64 BlockHeight[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("Locked")]
        Boolean Locked[JsonProperty("SubaddrIndex")]
        SubaddressIndex SubaddrIndex[JsonProperty("Address")]
        String Address
    }

    public class TransferDetails
    {
        [JsonProperty("Amount")]
        Int64 Amount[JsonProperty("Spent")]
        Boolean Spent[JsonProperty("GlobalIndex")]
        Int64 GlobalIndex[JsonProperty("TxHash")]
        String TxHash[JsonProperty("SubaddrIndex")]
        SubaddressIndex SubaddrIndex[JsonProperty("KeyImage")]
        String KeyImage[JsonProperty("BlockHeight")]
        Int64 BlockHeight[JsonProperty("Frozen")]
        Boolean Frozen[JsonProperty("Unlocked")]
        Boolean Unlocked
    }

    public class TransferEntry
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("Height")]
        Int64 Height[JsonProperty("Timestamp")]
        Int64 Timestamp[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("Amounts")]
        Int64 Amounts[JsonProperty("Fee")]
        Int64 Fee[JsonProperty("Note")]
        String Note[JsonProperty("Destinations")]
        List<TransferDestination> Destinations[JsonProperty("Type")]
        String Type[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("Locked")]
        Boolean Locked[JsonProperty("SubaddrIndex")]
        SubaddressIndex SubaddrIndex[JsonProperty("SubaddrIndices")]
        SubaddressIndex SubaddrIndices[JsonProperty("Address")]
        String Address[JsonProperty("DoubleSpendSeen")]
        Boolean DoubleSpendSeen[JsonProperty("Confirmations")]
        Int64 Confirmations[JsonProperty("SuggestedConfirmationsThreshold")]
        Int64 SuggestedConfirmationsThreshold
    }

    public class SignedKeyImage
    {
        [JsonProperty("KeyImage")]
        String KeyImage[JsonProperty("Signature")]
        String Signature
    }

    public class SignedKeyImage
    {
        [JsonProperty("KeyImage")]
        String KeyImage[JsonProperty("Signature")]
        String Signature
    }

    public class UriSpec
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("TxDescription")]
        String TxDescription[JsonProperty("RecipientName")]
        String RecipientName
    }

    public class Entry
    {
        [JsonProperty("Index")]
        Int64 Index[JsonProperty("Address")]
        String Address[JsonProperty("Description")]
        String Description
    }

    public class Request
    {
        [JsonProperty("RestoreHeight")]
        Int64 RestoreHeight[JsonProperty("Filename")]
        String Filename[JsonProperty("Address")]
        String Address[JsonProperty("Spendkey")]
        String Spendkey[JsonProperty("Viewkey")]
        String Viewkey[JsonProperty("Password")]
        String Password[JsonProperty("AutosaveCurrent")]
        Boolean AutosaveCurrent[JsonProperty("Language")]
        String Language
    }

    public class Response
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Info")]
        String Info
    }

    public class RpcGetBalanceParameters
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("AddressIndices")]
        Int32 AddressIndices[JsonProperty("AllAccounts")]
        Boolean AllAccounts[JsonProperty("Strict")]
        Boolean Strict
    }

    public class RpcGetBalanceResult
    {
        [JsonProperty("Balance")]
        Int64 Balance[JsonProperty("UnlockedBalance")]
        Int64 UnlockedBalance[JsonProperty("MultisigImportNeeded")]
        Boolean MultisigImportNeeded[JsonProperty("PerSubaddress")]
        List<PerSubaddressInfo> PerSubaddress[JsonProperty("BlocksToUnlock")]
        Int64 BlocksToUnlock[JsonProperty("TimeToUnlock")]
        Int64 TimeToUnlock
    }

    public class RpcGetAddressParameters
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("AddressIndex")]
        Int32 AddressIndex
    }

    public class RpcGetAddressResult
    {
        [JsonProperty("Addresses")]
        List<AddressInfo> Addresses
    }

    public class RpcGetAddressIndexParameters
    {
        [JsonProperty("Address")]
        String Address
    }

    public class RpcGetAddressIndexResult
    {
        [JsonProperty("Index")]
        SubaddressIndex Index
    }

    public class RpcCreateAddressParameters
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("Count")]
        Int32 Count[JsonProperty("Label")]
        String Label
    }

    public class RpcCreateAddressResult
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("AddressIndex")]
        Int32 AddressIndex[JsonProperty("Addresses")]
        String Addresses[JsonProperty("AddressIndices")]
        Int32 AddressIndices
    }

    public class RpcLabelAddressParameters
    {
        [JsonProperty("Index")]
        SubaddressIndex Index[JsonProperty("Label")]
        String Label
    }

    public class RpcLabelAddressResult
    {
    }

    public class RpcGetAccountsParameters
    {
        [JsonProperty("StrictBalances")]
        Boolean StrictBalances
    }

    public class RpcGetAccountsResult
    {
        [JsonProperty("TotalBalance")]
        Int64 TotalBalance[JsonProperty("TotalUnlockedBalance")]
        Int64 TotalUnlockedBalance[JsonProperty("SubaddressAccounts")]
        List<SubaddressAccountInfo> SubaddressAccounts
    }

    public class RpcCreateAccountParameters
    {
        [JsonProperty("Label")]
        String Label
    }

    public class RpcCreateAccountResult
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex
    }

    public class RpcLabelAccountParameters
    {
        [JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("Label")]
        String Label
    }

    public class RpcLabelAccountResult
    {
    }

    public class RpcGetAccountTagsParameters
    {
    }

    public class RpcGetAccountTagsResult
    {
        [JsonProperty("AccountTags")]
        List<AccountTagInfo> AccountTags
    }

    public class RpcTagAccountsParameters
    {
        [JsonProperty("Tag")]
        String Tag[JsonProperty("Accounts")]
        Int32 Accounts
    }

    public class RpcTagAccountsResult
    {
    }

    public class RpcUntagAccountsParameters
    {
        [JsonProperty("Accounts")]
        Int32 Accounts
    }

    public class RpcUntagAccountsResult
    {
    }

    public class RpcSetAccountTagDescriptionParameters
    {
        [JsonProperty("Tag")]
        String Tag[JsonProperty("Description")]
        String Description
    }

    public class RpcSetAccountTagDescriptionResult
    {
    }

    public class RpcGetHeightParameters
    {
    }

    public class RpcGetHeightResult
    {
        [JsonProperty("Height")]
        Int64 Height
    }

    public class RpcTransferParameters
    {
        [JsonProperty("Destinations")]
        List<TransferDestination> Destinations[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("SubaddrIndices")]
        Int32 SubaddrIndices[JsonProperty("Priority")]
        Int32 Priority[JsonProperty("RingSize")]
        Int64 RingSize[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("GetTxKey")]
        Boolean GetTxKey[JsonProperty("DoNotRelay")]
        Boolean DoNotRelay[JsonProperty("GetTxHex")]
        Boolean GetTxHex[JsonProperty("GetTxMetadata")]
        Boolean GetTxMetadata
    }

    public class RpcTransferResult
    {
        [JsonProperty("TxHash")]
        String TxHash[JsonProperty("TxKey")]
        String TxKey[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("Fee")]
        Int64 Fee[JsonProperty("Weight")]
        Int64 Weight[JsonProperty("TxBlob")]
        String TxBlob[JsonProperty("TxMetadata")]
        String TxMetadata[JsonProperty("MultisigTxset")]
        String MultisigTxset[JsonProperty("UnsignedTxset")]
        String UnsignedTxset
    }

    public class RpcTransferSplitParameters
    {
        [JsonProperty("Destinations")]
        List<TransferDestination> Destinations[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("SubaddrIndices")]
        Int32 SubaddrIndices[JsonProperty("Priority")]
        Int32 Priority[JsonProperty("RingSize")]
        Int64 RingSize[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("GetTxKeys")]
        Boolean GetTxKeys[JsonProperty("DoNotRelay")]
        Boolean DoNotRelay[JsonProperty("GetTxHex")]
        Boolean GetTxHex[JsonProperty("GetTxMetadata")]
        Boolean GetTxMetadata
    }

    public class RpcTransferSplitResult
    {
        [JsonProperty("TxHashList")]
        String TxHashList[JsonProperty("TxKeyList")]
        String TxKeyList[JsonProperty("AmountList")]
        Int64 AmountList[JsonProperty("FeeList")]
        Int64 FeeList[JsonProperty("WeightList")]
        Int64 WeightList[JsonProperty("TxBlobList")]
        String TxBlobList[JsonProperty("TxMetadataList")]
        String TxMetadataList[JsonProperty("MultisigTxset")]
        String MultisigTxset[JsonProperty("UnsignedTxset")]
        String UnsignedTxset
    }

    public class RpcDescribeTransferParameters
    {
        [JsonProperty("UnsignedTxset")]
        String UnsignedTxset[JsonProperty("MultisigTxset")]
        String MultisigTxset
    }

    public class RpcDescribeTransferResult
    {
        [JsonProperty("Desc")]
        List<TransferDescription> Desc
    }

    public class RpcSignTransferParameters
    {
        [JsonProperty("UnsignedTxset")]
        String UnsignedTxset[JsonProperty("ExportRaw")]
        Boolean ExportRaw[JsonProperty("GetTxKeys")]
        Boolean GetTxKeys
    }

    public class RpcSignTransferResult
    {
        [JsonProperty("SignedTxset")]
        String SignedTxset[JsonProperty("TxHashList")]
        String TxHashList[JsonProperty("TxRawList")]
        String TxRawList[JsonProperty("TxKeyList")]
        String TxKeyList
    }

    public class RpcSubmitTransferParameters
    {
        [JsonProperty("TxDataHex")]
        String TxDataHex
    }

    public class RpcSubmitTransferResult
    {
        [JsonProperty("TxHashList")]
        String TxHashList
    }

    public class RpcSweepDustParameters
    {
        [JsonProperty("GetTxKeys")]
        Boolean GetTxKeys[JsonProperty("DoNotRelay")]
        Boolean DoNotRelay[JsonProperty("GetTxHex")]
        Boolean GetTxHex[JsonProperty("GetTxMetadata")]
        Boolean GetTxMetadata
    }

    public class RpcSweepDustResult
    {
        [JsonProperty("TxHashList")]
        String TxHashList[JsonProperty("TxKeyList")]
        String TxKeyList[JsonProperty("AmountList")]
        Int64 AmountList[JsonProperty("FeeList")]
        Int64 FeeList[JsonProperty("WeightList")]
        Int64 WeightList[JsonProperty("TxBlobList")]
        String TxBlobList[JsonProperty("TxMetadataList")]
        String TxMetadataList[JsonProperty("MultisigTxset")]
        String MultisigTxset[JsonProperty("UnsignedTxset")]
        String UnsignedTxset
    }

    public class RpcSweepAllParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("SubaddrIndices")]
        Int32 SubaddrIndices[JsonProperty("SubaddrIndicesAll")]
        Boolean SubaddrIndicesAll[JsonProperty("Priority")]
        Int32 Priority[JsonProperty("RingSize")]
        Int64 RingSize[JsonProperty("Outputs")]
        Int64 Outputs[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("GetTxKeys")]
        Boolean GetTxKeys[JsonProperty("BelowAmount")]
        Int64 BelowAmount[JsonProperty("DoNotRelay")]
        Boolean DoNotRelay[JsonProperty("GetTxHex")]
        Boolean GetTxHex[JsonProperty("GetTxMetadata")]
        Boolean GetTxMetadata
    }

    public class RpcSweepAllResult
    {
        [JsonProperty("TxHashList")]
        String TxHashList[JsonProperty("TxKeyList")]
        String TxKeyList[JsonProperty("AmountList")]
        Int64 AmountList[JsonProperty("FeeList")]
        Int64 FeeList[JsonProperty("WeightList")]
        Int64 WeightList[JsonProperty("TxBlobList")]
        String TxBlobList[JsonProperty("TxMetadataList")]
        String TxMetadataList[JsonProperty("MultisigTxset")]
        String MultisigTxset[JsonProperty("UnsignedTxset")]
        String UnsignedTxset
    }

    public class RpcSweepSingleParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Priority")]
        Int32 Priority[JsonProperty("RingSize")]
        Int64 RingSize[JsonProperty("Outputs")]
        Int64 Outputs[JsonProperty("UnlockTime")]
        Int64 UnlockTime[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("GetTxKey")]
        Boolean GetTxKey[JsonProperty("KeyImage")]
        String KeyImage[JsonProperty("DoNotRelay")]
        Boolean DoNotRelay[JsonProperty("GetTxHex")]
        Boolean GetTxHex[JsonProperty("GetTxMetadata")]
        Boolean GetTxMetadata
    }

    public class RpcSweepSingleResult
    {
        [JsonProperty("TxHash")]
        String TxHash[JsonProperty("TxKey")]
        String TxKey[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("Fee")]
        Int64 Fee[JsonProperty("Weight")]
        Int64 Weight[JsonProperty("TxBlob")]
        String TxBlob[JsonProperty("TxMetadata")]
        String TxMetadata[JsonProperty("MultisigTxset")]
        String MultisigTxset[JsonProperty("UnsignedTxset")]
        String UnsignedTxset
    }

    public class RpcRelayTxParameters
    {
        [JsonProperty("Hex")]
        String Hex
    }

    public class RpcRelayTxResult
    {
        [JsonProperty("TxHash")]
        String TxHash
    }

    public class RpcStoreParameters
    {
    }

    public class RpcStoreResult
    {
    }

    public class RpcGetPaymentsParameters
    {
        [JsonProperty("PaymentId")]
        String PaymentId
    }

    public class RpcGetPaymentsResult
    {
        [JsonProperty("Payments")]
        List<PaymentDetails> Payments
    }

    public class RpcGetBulkPaymentsParameters
    {
        [JsonProperty("PaymentIds")]
        String PaymentIds[JsonProperty("MinBlockHeight")]
        Int64 MinBlockHeight
    }

    public class RpcGetBulkPaymentsResult
    {
        [JsonProperty("Payments")]
        List<PaymentDetails> Payments
    }

    public class RpcIncomingTransfersParameters
    {
        [JsonProperty("TransferType")]
        String TransferType[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("SubaddrIndices")]
        Int32 SubaddrIndices
    }

    public class RpcIncomingTransfersResult
    {
        [JsonProperty("Transfers")]
        List<TransferDetails> Transfers
    }

    public class RpcQueryKeyParameters
    {
        [JsonProperty("KeyType")]
        String KeyType
    }

    public class RpcQueryKeyResult
    {
        [JsonProperty("Key")]
        String Key
    }

    public class RpcMakeIntegratedAddressParameters
    {
        [JsonProperty("StandardAddress")]
        String StandardAddress[JsonProperty("PaymentId")]
        String PaymentId
    }

    public class RpcMakeIntegratedAddressResult
    {
        [JsonProperty("IntegratedAddress")]
        String IntegratedAddress[JsonProperty("PaymentId")]
        String PaymentId
    }

    public class RpcSplitIntegratedAddressParameters
    {
        [JsonProperty("IntegratedAddress")]
        String IntegratedAddress
    }

    public class RpcSplitIntegratedAddressResult
    {
        [JsonProperty("StandardAddress")]
        String StandardAddress[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("IsSubaddress")]
        Boolean IsSubaddress
    }

    public class RpcStopWalletParameters
    {
    }

    public class RpcStopWalletResult
    {
    }

    public class RpcRescanBlockchainParameters
    {
        [JsonProperty("Hard")]
        Boolean Hard
    }

    public class RpcRescanBlockchainResult
    {
    }

    public class RpcSetTxNotesParameters
    {
        [JsonProperty("Txids")]
        String Txids[JsonProperty("Notes")]
        String Notes
    }

    public class RpcSetTxNotesResult
    {
    }

    public class RpcGetTxNotesParameters
    {
        [JsonProperty("Txids")]
        String Txids
    }

    public class RpcGetTxNotesResult
    {
        [JsonProperty("Notes")]
        String Notes
    }

    public class RpcSetAttributeParameters
    {
        [JsonProperty("Key")]
        String Key[JsonProperty("Value")]
        String Value
    }

    public class RpcSetAttributeResult
    {
    }

    public class RpcGetAttributeParameters
    {
        [JsonProperty("Key")]
        String Key
    }

    public class RpcGetAttributeResult
    {
        [JsonProperty("Value")]
        String Value
    }

    public class RpcGetTxKeyParameters
    {
        [JsonProperty("Txid")]
        String Txid
    }

    public class RpcGetTxKeyResult
    {
        [JsonProperty("TxKey")]
        String TxKey
    }

    public class RpcCheckTxKeyParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("TxKey")]
        String TxKey[JsonProperty("Address")]
        String Address
    }

    public class RpcCheckTxKeyResult
    {
        [JsonProperty("Received")]
        Int64 Received[JsonProperty("InPool")]
        Boolean InPool[JsonProperty("Confirmations")]
        Int64 Confirmations
    }

    public class RpcGetTxProofParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("Address")]
        String Address[JsonProperty("Message")]
        String Message
    }

    public class RpcGetTxProofResult
    {
        [JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckTxProofParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("Address")]
        String Address[JsonProperty("Message")]
        String Message[JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckTxProofResult
    {
        [JsonProperty("Good")]
        Boolean Good[JsonProperty("Received")]
        Int64 Received[JsonProperty("InPool")]
        Boolean InPool[JsonProperty("Confirmations")]
        Int64 Confirmations
    }

    public class RpcGetSpendProofParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("Message")]
        String Message
    }

    public class RpcGetSpendProofResult
    {
        [JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckSpendProofParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("Message")]
        String Message[JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckSpendProofResult
    {
        [JsonProperty("Good")]
        Boolean Good
    }

    public class RpcGetReserveProofParameters
    {
        [JsonProperty("All")]
        Boolean All[JsonProperty("Message")]
        String Message
    }

    public class RpcGetReserveProofResult
    {
        [JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckReserveProofParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Message")]
        String Message[JsonProperty("Signature")]
        String Signature
    }

    public class RpcCheckReserveProofResult
    {
        [JsonProperty("Good")]
        Boolean Good[JsonProperty("Total")]
        Int64 Total[JsonProperty("Spent")]
        Int64 Spent
    }

    public class RpcGetTransfersParameters
    {
        [JsonProperty("In")]
        Boolean In[JsonProperty("Out")]
        Boolean Out[JsonProperty("Pending")]
        Boolean Pending[JsonProperty("Failed")]
        Boolean Failed[JsonProperty("Pool")]
        Boolean Pool[JsonProperty("FilterByHeight")]
        Boolean FilterByHeight[JsonProperty("MinHeight")]
        Int64 MinHeight[JsonProperty("MaxHeight")]
        Int64 MaxHeight[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("SubaddrIndices")]
        Int32 SubaddrIndices[JsonProperty("AllAccounts")]
        Boolean AllAccounts
    }

    public class RpcGetTransfersResult
    {
        [JsonProperty("In")]
        List<TransferEntry> In[JsonProperty("Out")]
        List<TransferEntry> Out[JsonProperty("Pending")]
        List<TransferEntry> Pending[JsonProperty("Failed")]
        List<TransferEntry> Failed[JsonProperty("Pool")]
        List<TransferEntry> Pool
    }

    public class RpcGetTransferByTxidParameters
    {
        [JsonProperty("Txid")]
        String Txid[JsonProperty("AccountIndex")]
        Int32 AccountIndex
    }

    public class RpcGetTransferByTxidResult
    {
        [JsonProperty("Transfer")]
        TransferEntry Transfer[JsonProperty("Transfers")]
        List<TransferEntry> Transfers
    }

    public class RpcSignParameters
    {
        [JsonProperty("Data")]
        String Data[JsonProperty("AccountIndex")]
        Int32 AccountIndex[JsonProperty("AddressIndex")]
        Int32 AddressIndex[JsonProperty("SignatureType")]
        String SignatureType
    }

    public class RpcSignResult
    {
        [JsonProperty("Signature")]
        String Signature
    }

    public class RpcVerifyParameters
    {
        [JsonProperty("Data")]
        String Data[JsonProperty("Address")]
        String Address[JsonProperty("Signature")]
        String Signature
    }

    public class RpcVerifyResult
    {
        [JsonProperty("Good")]
        Boolean Good[JsonProperty("Version")]
        UInt32 Version[JsonProperty("Old")]
        Boolean Old[JsonProperty("SignatureType")]
        String SignatureType
    }

    public class RpcExportOutputsParameters
    {
        [JsonProperty("All")]
        Boolean All
    }

    public class RpcExportOutputsResult
    {
        [JsonProperty("OutputsDataHex")]
        String OutputsDataHex
    }

    public class RpcImportOutputsParameters
    {
        [JsonProperty("OutputsDataHex")]
        String OutputsDataHex
    }

    public class RpcImportOutputsResult
    {
        [JsonProperty("NumImported")]
        Int64 NumImported
    }

    public class RpcExportKeyImagesParameters
    {
        [JsonProperty("All")]
        Boolean All
    }

    public class RpcExportKeyImagesResult
    {
        [JsonProperty("Offset")]
        Int32 Offset[JsonProperty("SignedKeyImages")]
        List<SignedKeyImage> SignedKeyImages
    }

    public class RpcImportKeyImagesParameters
    {
        [JsonProperty("Offset")]
        Int32 Offset[JsonProperty("SignedKeyImages")]
        List<SignedKeyImage> SignedKeyImages
    }

    public class RpcImportKeyImagesResult
    {
        [JsonProperty("Height")]
        Int64 Height[JsonProperty("Spent")]
        Int64 Spent[JsonProperty("Unspent")]
        Int64 Unspent
    }

    public class RpcMakeUriParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("PaymentId")]
        String PaymentId[JsonProperty("Amount")]
        Int64 Amount[JsonProperty("TxDescription")]
        String TxDescription[JsonProperty("RecipientName")]
        String RecipientName
    }

    public class RpcMakeUriResult
    {
        [JsonProperty("Uri")]
        String Uri
    }

    public class RpcParseUriParameters
    {
        [JsonProperty("Uri")]
        String Uri
    }

    public class RpcParseUriResult
    {
        [JsonProperty("Uri")]
        UriSpec Uri[JsonProperty("UnknownParameters")]
        String UnknownParameters
    }

    public class RpcAddAddressBookEntryParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Description")]
        String Description
    }

    public class RpcAddAddressBookEntryResult
    {
        [JsonProperty("Index")]
        Int64 Index
    }

    public class RpcEditAddressBookEntryParameters
    {
        [JsonProperty("Index")]
        Int64 Index[JsonProperty("SetAddress")]
        Boolean SetAddress[JsonProperty("Address")]
        String Address[JsonProperty("SetDescription")]
        Boolean SetDescription[JsonProperty("Description")]
        String Description
    }

    public class RpcEditAddressBookEntryResult
    {
    }

    public class RpcGetAddressBookEntryParameters
    {
        [JsonProperty("Entries")]
        Int64 Entries
    }

    public class RpcGetAddressBookEntryResult
    {
        [JsonProperty("Entries")]
        List<Entry> Entries
    }

    public class RpcDeleteAddressBookEntryParameters
    {
        [JsonProperty("Index")]
        Int64 Index
    }

    public class RpcDeleteAddressBookEntryResult
    {
    }

    public class RpcRescanSpentParameters
    {
    }

    public class RpcRescanSpentResult
    {
    }

    public class RpcRefreshParameters
    {
        [JsonProperty("StartHeight")]
        Int64 StartHeight
    }

    public class RpcRefreshResult
    {
        [JsonProperty("BlocksFetched")]
        Int64 BlocksFetched[JsonProperty("ReceivedMoney")]
        Boolean ReceivedMoney
    }

    public class RpcAutoRefreshParameters
    {
        [JsonProperty("Enable")]
        Boolean Enable
    }

    public class RpcAutoRefreshResult
    {
    }

    public class RpcScanTxParameters
    {
        [JsonProperty("Txids")]
        String Txids
    }

    public class RpcScanTxResult
    {
    }

    public class RpcStartMiningParameters
    {
        [JsonProperty("ThreadsCount")]
        Int64 ThreadsCount[JsonProperty("DoBackgroundMining")]
        Boolean DoBackgroundMining[JsonProperty("IgnoreBattery")]
        Boolean IgnoreBattery
    }

    public class RpcStartMiningResult
    {
    }

    public class RpcStopMiningParameters
    {
    }

    public class RpcStopMiningResult
    {
    }

    public class RpcGetLanguagesParameters
    {
    }

    public class RpcGetLanguagesResult
    {
        [JsonProperty("Languages")]
        String Languages[JsonProperty("LanguagesLocal")]
        String LanguagesLocal
    }

    public class RpcCreateWalletParameters
    {
        [JsonProperty("Filename")]
        String Filename[JsonProperty("Password")]
        String Password[JsonProperty("Language")]
        String Language
    }

    public class RpcCreateWalletResult
    {
    }

    public class RpcOpenWalletParameters
    {
        [JsonProperty("Filename")]
        String Filename[JsonProperty("Password")]
        String Password[JsonProperty("AutosaveCurrent")]
        Boolean AutosaveCurrent
    }

    public class RpcOpenWalletResult
    {
    }

    public class RpcCloseWalletParameters
    {
        [JsonProperty("AutosaveCurrent")]
        Boolean AutosaveCurrent
    }

    public class RpcCloseWalletResult
    {
    }

    public class RpcChangeWalletPasswordParameters
    {
        [JsonProperty("OldPassword")]
        String OldPassword[JsonProperty("NewPassword")]
        String NewPassword
    }

    public class RpcChangeWalletPasswordResult
    {
    }

    public class RpcGenerateFromKeysParameters
    {
    }

    public class RpcGenerateFromKeysResult
    {
    }

    public class RpcRestoreDeterministicWalletParameters
    {
        [JsonProperty("RestoreHeight")]
        Int64 RestoreHeight[JsonProperty("Filename")]
        String Filename[JsonProperty("Seed")]
        String Seed[JsonProperty("SeedOffset")]
        String SeedOffset[JsonProperty("Password")]
        String Password[JsonProperty("Language")]
        String Language[JsonProperty("AutosaveCurrent")]
        Boolean AutosaveCurrent
    }

    public class RpcRestoreDeterministicWalletResult
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Seed")]
        String Seed[JsonProperty("Info")]
        String Info[JsonProperty("WasDeprecated")]
        Boolean WasDeprecated
    }

    public class RpcIsMultisigParameters
    {
    }

    public class RpcIsMultisigResult
    {
        [JsonProperty("Multisig")]
        Boolean Multisig[JsonProperty("Ready")]
        Boolean Ready[JsonProperty("Threshold")]
        Int32 Threshold[JsonProperty("Total")]
        Int32 Total
    }

    public class RpcPrepareMultisigParameters
    {
    }

    public class RpcPrepareMultisigResult
    {
        [JsonProperty("MultisigInfo")]
        String MultisigInfo
    }

    public class RpcMakeMultisigParameters
    {
        [JsonProperty("MultisigInfo")]
        String MultisigInfo[JsonProperty("Threshold")]
        Int32 Threshold[JsonProperty("Password")]
        String Password
    }

    public class RpcMakeMultisigResult
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("MultisigInfo")]
        String MultisigInfo
    }

    public class RpcExportMultisigParameters
    {
    }

    public class RpcExportMultisigResult
    {
        [JsonProperty("Info")]
        String Info
    }

    public class RpcImportMultisigParameters
    {
        [JsonProperty("Info")]
        String Info
    }

    public class RpcImportMultisigResult
    {
        [JsonProperty("NOutputs")]
        Int64 NOutputs
    }

    public class RpcFinalizeMultisigParameters
    {
        [JsonProperty("Password")]
        String Password[JsonProperty("MultisigInfo")]
        String MultisigInfo
    }

    public class RpcFinalizeMultisigResult
    {
        [JsonProperty("Address")]
        String Address
    }

    public class RpcExchangeMultisigKeysParameters
    {
        [JsonProperty("Password")]
        String Password[JsonProperty("MultisigInfo")]
        String MultisigInfo
    }

    public class RpcExchangeMultisigKeysResult
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("MultisigInfo")]
        String MultisigInfo
    }

    public class RpcSignMultisigParameters
    {
        [JsonProperty("TxDataHex")]
        String TxDataHex
    }

    public class RpcSignMultisigResult
    {
        [JsonProperty("TxDataHex")]
        String TxDataHex[JsonProperty("TxHashList")]
        String TxHashList
    }

    public class RpcSubmitMultisigParameters
    {
        [JsonProperty("TxDataHex")]
        String TxDataHex
    }

    public class RpcSubmitMultisigResult
    {
        [JsonProperty("TxHashList")]
        String TxHashList
    }

    public class RpcGetVersionParameters
    {
    }

    public class RpcGetVersionResult
    {
        [JsonProperty("Version")]
        Int32 Version[JsonProperty("Release")]
        Boolean Release
    }

    public class RpcValidateAddressParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("AnyNetType")]
        Boolean AnyNetType[JsonProperty("AllowOpenalias")]
        Boolean AllowOpenalias
    }

    public class RpcValidateAddressResult
    {
        [JsonProperty("Valid")]
        Boolean Valid[JsonProperty("Integrated")]
        Boolean Integrated[JsonProperty("Subaddress")]
        Boolean Subaddress[JsonProperty("Nettype")]
        String Nettype[JsonProperty("OpenaliasAddress")]
        String OpenaliasAddress
    }

    public class RpcSetDaemonParameters
    {
        [JsonProperty("Address")]
        String Address[JsonProperty("Trusted")]
        Boolean Trusted[JsonProperty("SslPrivateKeyPath")]
        String SslPrivateKeyPath[JsonProperty("SslCertificatePath")]
        String SslCertificatePath[JsonProperty("SslCaFile")]
        String SslCaFile[JsonProperty("SslAllowedFingerprints")]
        String SslAllowedFingerprints[JsonProperty("SslAllowAnyCert")]
        Boolean SslAllowAnyCert
    }

    public class RpcSetDaemonResult
    {
    }

    public class RpcSetLogLevelParameters
    {
        [JsonProperty("Level")]
        Byte Level
    }

    public class RpcSetLogLevelResult
    {
    }

    public class RpcSetLogCategoriesParameters
    {
        [JsonProperty("Categories")]
        String Categories
    }

    public class RpcSetLogCategoriesResult
    {
        [JsonProperty("Categories")]
        String Categories
    }

    public class RpcEstimateTxSizeAndWeightParameters
    {
        [JsonProperty("NInputs")]
        Int32 NInputs[JsonProperty("NOutputs")]
        Int32 NOutputs[JsonProperty("RingSize")]
        Int32 RingSize[JsonProperty("Rct")]
        Boolean Rct
    }

    public class RpcEstimateTxSizeAndWeightResult
    {
        [JsonProperty("Size")]
        Int64 Size[JsonProperty("Weight")]
        Int64 Weight
    }
}
