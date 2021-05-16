using System.Collections.Generic;
using AutoMapper;

namespace MoneroPay.API.Configuration
{
    public enum MoneroSslSetting
    {
        Enabled,
        Disabled,
        Autodetect
    }

    public record WalletRpcCliParameters
    {
        [CliParameter("--daemon-address")] public string? DaemonAddress { get; set; }
        [CliParameter("--daemon-host")] public string? DaemonHost { get; set; }
        [CliParameter("--proxy")] public string? SocksProxy { get; set; }
        [CliParameter("--trusted-daemon")] public bool? TrustedDaemon { get; set; }
        [CliParameter("--untrusted-daemon")] public bool? UntrustedDaemon { get; set; }
        [CliParameter("--password")] public string? Password { get; set; }
        [CliParameter("--password-file")] public string? PasswordFile { get; set; }
        [CliParameter("--daemon-port")] public int? DaemonPort { get; set; }
        [CliParameter("--daemon-login")] public string? DaemonLogin { get; set; }
        [CliParameter("--daemon-ssl")] public MoneroSslSetting? DaemonSsl { get; set; }
        [CliParameter("--daemon-ssl-private-key")] public string? DaemonSslPrivateKey { get; set; }
        [CliParameter("--daemon-ssl-certificate")] public string? DaemonSslCertificate { get; set; }
        [CliParameter("--daemon-ssl-ca-certificates")] public string? DaemonSslCaCertificates { get; set; }
        [CliParameter("--daemon-ssl-allowed-fingerprints")] public string? DaemonSslAllowedFingerprints { get; set; }
        [CliParameter("--daemon-ssl-allow-any-cert")] public bool? DaemonSslAllowAnyCert { get; set; }
        [CliParameter("--daemon-ssl-allow-chained")] public bool? DaemonSslAllowChained { get; set; }
        [CliParameter("--testnet")] public bool? Testnet { get; set; }
        [CliParameter("--stagenet")] public bool? Stagenet { get; set; }
        [CliParameter("--shared-ringdb-dir")] public string? SharedRingDbDir { get; set; }
        [CliParameter("--kdf-rounds")] public int? KdfRounds { get; set; }
        [CliParameter("--hw-device")] public string? HwDevice { get; set; }
        [CliParameter("--hw-device-deriv-path")] public string? HwDeviceDerivationPath { get; set; }
        [CliParameter("--tx-notify")] public string? TxNotify { get; set; }
        [CliParameter("--no-dns")] public bool? NoDns { get; set; }
        [CliParameter("--offline")] public bool? Offline { get; set; }
        [CliParameter("--extra-entropy")] public string? ExtraEntropy { get; set; }
        [CliParameter("--rpc-bind-port")] public int? RpcBindPort { get; set; }
        [CliParameter("--disable-rpc-login")] public bool? DisableRpcLogin { get; set; }
        [CliParameter("--restrict-rpc")] public bool? RestrictedRpc { get; set; }
        [CliParameter("--rpc-bind-ip")] public string? RpcBindIp { get; set; }
        [CliParameter("--rpc-bind-ipv6-address")] public string? RpcBindIpV6Address { get; set; }
        [CliParameter("--rpc-restricted-bind-ip")] public string? RpcRestrictedBindIp { get; set; }
        [CliParameter("--rpc-restricted-bind-ipv6-address")] public string? RpcRestrictedBindIpV6Address { get; set; }
        [CliParameter("--rpc-use-ipv6")] public bool? RpcUseIpV6 { get; set; }
        [CliParameter("--rpc-ignore-ipv4")] public bool? RpcIgnoreIpV4 { get; set; }
        [CliParameter("--rpc-login")] public string? RpcLogin { get; set; }
        [CliParameter("--confirm-external-bind")] public bool? ConfirmExternalBind { get; set; }
        [CliParameter("--rpc-access-control-origins")] public string? RpcAccessControlOrigins { get; set; }
        [CliParameter("--rpc-ssl")] public MoneroSslSetting? RpcSsl { get; set; }
        [CliParameter("--rpc-ssl-private-key")] public string? RpcSslPrivateKey { get; set; }
        [CliParameter("--rpc-ssl-certificate")] public string? RpcSslCaCertificates { get; set; }
        [CliParameter("--rpc-ssl-allowed-fingerprints")] public string? RpcSslAllowedFingerprints { get; set; }
        [CliParameter("--rpc-ssl-allow-chained")] public bool? RpcSslAllowChained { get; set; }
        [CliParameter("--disable-rpc-ban")] public bool? DisableRpcBan { get; set; }
        [CliParameter("--wallet-file")] public string? WalletFile { get; set; }
        [CliParameter("--generate-from-json")] public string? GenerateFromJson { get; set; }
        [CliParameter("--wallet-dir")] public string? WalletDir { get; set; }
        [CliParameter("--rpc-client-secret-key")] public string? RpcClientSecretKey { get; set; }
        [CliParameter("--log-level")] public int? LogLevel { get; set; }
        [CliParameter("--log-file")] public string? LogFile { get; set; }
        [CliParameter("--max-concurrency")] public int? MaxConcurrency { get; set; }
        [CliParameter("--config-file")] public string? ConfigFile { get; set; }
    }

    public class WalletRpcCliParametersMappingProfile : Profile
    {
        public WalletRpcCliParametersMappingProfile()
        {
            CreateMap<WalletRpcCliParameters, WalletRpcCliParameters>();
        }
    }
}