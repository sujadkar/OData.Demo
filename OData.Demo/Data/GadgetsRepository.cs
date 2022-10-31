using Dapper;
using Dapper.Builder;
using Dapper.Builder.Core;
using Dapper.Builder.Processes;
using Dapper.Builder.Services;
using Microsoft.AspNetCore.Http.Extensions;
using OData.Demo.Data;
using OData.Demo.Data.Entities;
using Snowflake.Data.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OData.Demo.Data
{
    class GadgetsRepository : IGadgetsRepository
    {
        private IQueryBuilder<Gadgets> _query;
        public GadgetsRepository(IQueryBuilder<Gadgets> queryBuilder)
        {
            _query = queryBuilder;
        }

        public GadgetsRepository()
        {
            //_query = queryBuilder;
        }

        //public async Task<IEnumerable<Gadgets>> GetSomeSimpleStuff()
        //{
        //    //_query = new SnowflakeDbCommandBuilder();

        //    using (SnowflakeDbConnection snowflakeDbConnection = new SnowflakeDbConnection())
        //    {
        //        snowflakeDbConnection.ConnectionString = "account=ib65413.central-india.azure;user=SUJAY; password=Sujay@9860;ROLE=ACCOUNTADMIN; db =TEST_SNOWFLAKE;";
        //        snowflakeDbConnection.Open();

        //        SnowflakeDbDataAdapter snowflakeDbDataAdapter = new SnowflakeDbDataAdapter("select * from Gadgets",snowflakeDbConnection);
        //        DataSet dataSet = new DataSet();
        //        snowflakeDbDataAdapter.Fill(dataSet);


        //        return await _query.Columns(
        //                nameof(Gadgets.Id),
        //                nameof(Gadgets.Cost))
        //            .SortDescending(sc => sc.Id).ExecuteAsync();
        //        //snowflakeDbConnection.Close();
        //    }
        //}

        public async Task<IEnumerable<Gadgets>> GetSomeSimpleStuff()
        {
            //QueryResult queryResult = _query.GetQueryString();

            //IDbConnection dbConnection =  _query.GetContext();
            //dbConnection.Query("select * from Gadgets");
            //return await dbConnection.exe("select * from Gadgets");

            //string str = queryResult.Query.ToString().Replace('[', ' ');
            //str = str.ToString().Replace(']', ' ');
            //return await _query.ProcessConfig.ExecuteAsync();
            //QueryBuilderDependencies queryBuilderDependencies = new Dapper.Builder.QueryBuilderDependencies();

            //_query
            //_query.ProcessConfig(p => { p.})


            return await _query.ExecuteAsync();
        }
    }
}
