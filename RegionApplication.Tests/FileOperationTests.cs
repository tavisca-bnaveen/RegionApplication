using System;
using Xunit;

namespace RegionApplication.Tests
{
    public class FileOperationTests
    {
        [Fact]
        public void FileNotFound()
        {
            var fileOperation = new FileOperation();
            try
            {
                fileOperation.ReadLines("xyz");
            }
            catch(Exception ex)
            {
                Assert.Equal("FileNotFound", ex.Message);
            }
        }
    }
}
