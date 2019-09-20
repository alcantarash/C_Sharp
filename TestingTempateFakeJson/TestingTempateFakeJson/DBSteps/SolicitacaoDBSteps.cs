using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Helpers;

namespace TestingTempateFakeJson.DBSteps
{
    class SolicitacaoDBSteps
    {
        public static void AtualizaDataDoItemSolicitacaoParaAgoraDB(string solicitacaoItemId)
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Solicitacao/SolicitacaoItensAssitenciaisValidosJson.json", Encoding.UTF8);
            query = query.Replace("$solicitacaoItemId", solicitacaoItemId);

            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: solicitacaoItemId = " + solicitacaoItemId);
        }
    }
}
