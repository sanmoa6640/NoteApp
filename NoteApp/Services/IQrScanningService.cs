using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
