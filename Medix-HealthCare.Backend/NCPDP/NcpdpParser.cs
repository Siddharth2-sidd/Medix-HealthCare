using HealthcareSystem.Models;

namespace HealthcareSystem.NCPDP
{
    public class NcpdpParser
    {
        public static NcpdpClaim Parser(string rawData) {
            var claim = new NcpdpClaim();
            var lines = rawData.Split(',');

            foreach (var line in lines) {
                if(line.StartsWith("BIN:"))
                claim.Bin = line.Replace("BIN:", "").Trim();

                if(line.StartsWith("CARDHOLDERID"))
                    claim.CardholderId = int.Parse(
                        line.Replace("CARDHOLDERID:","").Trim());
                if (line.StartsWith("POLICY"))
                    claim.PolicyNumber = line.Replace("POLICY:", "").Trim();
                if (line.StartsWith("NDC:"))
                    claim.Ndc = line.Replace("NDC:", "").Trim();
                if (line.StartsWith("QUANTITY"))
                    claim.Quantity = int.Parse(
                        line.Replace("QUANTITY:", "").Trim());
                if (line.StartsWith("AMOUNT"))
                    claim.Amount = decimal.Parse(
                        line.Replace("AMOUNT:", "").Trim());
            }
            return claim;
        }
    }
}
