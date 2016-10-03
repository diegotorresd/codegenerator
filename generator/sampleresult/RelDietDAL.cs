using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using CodeGeneratorResult;

namespace DAL
{
    public partial class RelDietDAL : IDAL<RelDietEntity>
    {
        IDbConnection Connection;

        public RelDietDAL(IDbConnection connection)
        {
            Connection = connection;
        }

        private const string UPDATE_AZ_DOC_REL_DIET = "PKG_AZ_DOC_REL_DIET.PR_UPDATE";
        private const String GET_AZ_DOC_REL_DIET = "PKG_AZ_DOC_REL_DIET.PR_GET";
        private const String INSERT_AZ_DOC_REL_DIET = "PKG_AZ_DOC_REL_DIET.PR_INSERT";
        private const String GET_ALL_AZ_DOC_REL_DIET = "PKG_AZ_DOC_REL_DIET.PR_GET_ALL";
        private const String DELETE_AZ_DOC_REL_DIET = "PKG_AZ_DOC_REL_DIET.PR_DELETE";

        public bool Delete(int id)
        {
            int result = 0;
            var cmd = Connection.CreateCommand();
            cmd.CommandText = DELETE_AZ_DOC_REL_DIET;
            cmd.CommandType = CommandType.StoredProcedure;

            var tableIdParameter = cmd.CreateParameter();
            tableIdParameter.ParameterName = "PI_DIET_ID";
            tableIdParameter.DbType = DbType.Int32;
            tableIdParameter.Value = id;

            cmd.Parameters.Add(tableIdParameter);
            result = cmd.ExecuteNonQuery();

            if (result == 0)
                return false;

            return true;
        }

        public IEnumerable<RelDietEntity> GetAll(int fkId)
        {
            var cmd = Connection.CreateCommand();
            cmd.CommandText = GET_ALL_AZ_DOC_REL_DIET;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.AddParameter(DbType.Int32, "PI_REQUEST_ID", fkId);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = new RelDietEntity(reader);
                yield return item;
            }
        }

        public RelDietEntity Get(int id)
        {
            var cmd = Connection.CreateCommand();
            cmd.CommandText = GET_AZ_DOC_REL_DIET;
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.AddParameter(DbType.Int32, "PI_DIET_ID", id);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new RelDietEntity(reader);
            
            return new RelDietEntity();
        }

        public int Save(RelDietEntity ent)
        {
            var cmd = Connection.CreateCommand();
            cmd.CommandText = INSERT_AZ_DOC_REL_DIET;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.AddParameter(DbType.Int32, "PI_REQUEST_ID", ent.RequestId);
            cmd.AddParameter(DbType.Int32, "PI_TYPE_ID", ent.TypeId);
            cmd.AddParameter(DbType.String, "PI_REASON_TXT", ent.ReasonTxt);
            cmd.AddParameter(DbType.Int32, "PI_DECISION_ID", ent.DecisionId);

            //cmd.AddInParam("PI_REASON_TXT", DbType.String, ent.ReasonTxt);
            //cmd.AddInParam("PI_SUPPORT_TXT", DbType.String, ent.SupportTxt);
            //cmd.AddInParam("PI_MENU_TXT", DbType.String, ent.MenuTxt);
            //cmd.AddInParam("PI_INMATE_SIGNATURE_ID", DbType.Int32, ent.InmateSignatureId);
            //cmd.AddInParam("PI_OTHER_SIGNATURE_ID", DbType.Int32, ent.OtherSignatureId);
            //cmd.AddInParam("PI_INTERVIEW_DTM", DbType.DateTime, ent.InterviewDtm);
            //cmd.AddInParam("PI_DECISION_ID", DbType.Int32, ent.DecisionId);
            //cmd.AddInParam("PI_DECISION_DTM", DbType.DateTime, ent.DecisionDtm);
            //cmd.AddInParam("PI_FSL_REJECT_FLAG", DbType.StringFixedLength, ent.FslRejectFlag.ToChar());
            //cmd.AddInParam("PI_UPDT_USERID", DbType.Int32, ent.UpdtUserid);
            //cmd.AddInParam("PI_UPDT_DTM", DbType.DateTime, ent.UpdtDtm);

            cmd.AddOutParameter(DbType.Int32, "PO_DIET_ID");

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return (int)reader["PO_DIET_ID"];
            }

            return 0;
        }

        public int Update(RelDietEntity ent)
        {
            int result = 0;
            var cmd = Connection.CreateCommand();
            cmd.CommandText = UPDATE_AZ_DOC_REL_DIET;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.AddParameter(DbType.Int32, "PI_DIET_ID", ent.Id);
            cmd.AddParameter(DbType.Int32, "PI_REQUEST_ID", ent.RequestId);
            cmd.AddParameter(DbType.Int32, "PI_TYPE_ID", ent.TypeId);
            cmd.AddParameter(DbType.String, "PI_REASON_TXT", ent.ReasonTxt);
            cmd.AddParameter(DbType.Int32, "PI_DECISION_ID", ent.DecisionId);
            //cmd.AddInParam("PI_REASON_TXT", DbType.String, ent.ReasonTxt);
            //cmd.AddInParam("PI_SUPPORT_TXT", DbType.String, ent.SupportTxt);
            //cmd.AddInParam("PI_MENU_TXT", DbType.String, ent.MenuTxt);
            //cmd.AddInParam("PI_INMATE_SIGNATURE_ID", DbType.Int32, ent.InmateSignatureId);
            //cmd.AddInParam("PI_OTHER_SIGNATURE_ID", DbType.Int32, ent.OtherSignatureId);
            //cmd.AddInParam("PI_INTERVIEW_DTM", DbType.DateTime, ent.InterviewDtm);
            //cmd.AddInParam("PI_DECISION_ID", DbType.Int32, ent.DecisionId);
            //cmd.AddInParam("PI_DECISION_DTM", DbType.DateTime, ent.DecisionDtm);
            //cmd.AddInParam("PI_FSL_REJECT_FLAG", DbType.StringFixedLength, ent.FslRejectFlag.ToChar());
            //cmd.AddInParam("PI_UPDT_USERID", DbType.Int32, ent.UpdtUserid);
            //cmd.AddInParam("PI_UPDT_DTM", DbType.DateTime, ent.UpdtDtm);

            result = cmd.ExecuteNonQuery();
            if(result>0)
                return ent.Id;

            return result;
        }
    }
}