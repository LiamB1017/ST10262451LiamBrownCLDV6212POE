// /Shared/ContractFile.cs
using Azure.Storage.Files.Shares;
using System;

namespace ABC_Retail_App_Functions.Shared
{
    public class ContractFile
    {
        public string ShareName { get; set; } // e.g., "contracts"
        public string DirectoryName { get; set; } // e.g., "legal"
        public string FileName { get; set; }
        public long FileSize { get; set; }
        // Additional fields as needed
    }
}
