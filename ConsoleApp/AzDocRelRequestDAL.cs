using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using MD_MiCASE_DOC_Entities;
using MIServices.EA.Data;

namespace MD_MiCASE_DOC_Dal
{
    public class AzDocRelRequestDAL : MD_MiCASE_DOC_Dal.IAzDocRelRequestDAL
    {
        private readonly Database eaSql;
        private DatabaseHelper helper;

        public AzDocRelRequestDAL()
        {
            eaSql = DataConnector.GetConnection();
            helper = new DatabaseHelper(eaSql);
        }

        private const String UPDATE_AZ_DOC_REL_REQUEST = "PKG_AZ_DOC_REL_REQUEST.PR_UPDATE";
        private const String GET_AZ_DOC_REL_REQUEST = "PKG_AZ_DOC_REL_REQUEST.PR_GET";
        private const String INSERT_AZ_DOC_REL_REQUEST = "PKG_AZ_DOC_REL_REQUEST.PR_INSERT";
        private const String GET_ALL_AZ_DOC_REL_REQUEST = "PKG_AZ_DOC_REL_REQUEST.PR_GET_ALL";
        private const String DELETE_AZ_DOC_REL_REQUEST = "PKG_AZ_DOC_REL_REQUEST.PR_DELETE";


        public void UpdateAzDocRelRequest(AzDocRelRequestEntity ent) {
            using (var cmd = eaSql.CreateDbCommandWriter(UPDATE_AZ_DOC_REL_REQUEST, CommandType.StoredProcedure)) {
				cmd.AddInParam("PI_REQUEST_ID", DbType.Int32, ent.RequestId);
				cmd.AddInParam("PI_DOC_ID", DbType.Int32, ent.DocId);
				cmd.AddInParam("PI_TYPE_ID", DbType.Int32, ent.TypeId);
				cmd.AddInParam("PI_SUBTYPE_ID", DbType.Int32, ent.SubtypeId);
				cmd.AddInParam("PI_PROPERTY_TYPE_ID", DbType.Int32, ent.PropertyTypeId);
				cmd.AddInParam("PI_APPROVAL_ID", DbType.Int32, ent.ApprovalId);
				cmd.AddInParam("PI_COMMENTS", DbType.String, ent.Comments);
				cmd.AddInParam("PI_STATUS_ID", DbType.Int32, ent.StatusId);
				cmd.AddInParam("PI_REASON_TXT", DbType.String, ent.ReasonTxt);
				cmd.AddInParam("PI_DOCUMENT_ID", DbType.Int32, ent.DocumentId);
				cmd.AddInParam("PI_REQUEST_DTM", DbType.DateTime, ent.RequestDtm);
				cmd.AddInParam("PI_EXPIRATION_DTM", DbType.DateTime, ent.ExpirationDtm);
				cmd.AddInParam("PI_PENDING_NOTIFICATION", DbType.StringFixedLength, ent.PendingNotification.ToChar());
				cmd.AddInParam("PI_UPDT_USERID", DbType.Int32, ent.UpdtUserid);
				cmd.AddInParam("PI_UPDT_DTM", DbType.DateTime, ent.UpdtDtm);
				cmd.AddInParam("PI_CHANGE_ID", DbType.Int32, ent.ChangeId);
                helper.ExecuteNonQuery(cmd);
            }
        }

        public AzDocRelRequestEntity GetAzDocRelRequest(Int32 requestId)
        {
            var ent = new AzDocRelRequestEntity();
            using (var cmd = eaSql.CreateDbCommandWriter(GET_AZ_DOC_REL_REQUEST, CommandType.StoredProcedure))
            {
                cmd.AddInParam("PI_REQUEST_ID", DbType.Int32, requestId);
                using (var ds = new DataSet())
                {
                    helper.LoadDataSet(cmd, ds, "Results");
                    DataTable dt = ds.Tables["Results"];
                    if (dt.Rows.Count > 0)
                    {
                        ent.MapFromRow(dt.Rows[0]);
                    }
                }
            }
            return ent;
        }

        public Int32 SaveAzDocRelRequest(AzDocRelRequestEntity ent) 
        {
            Int32 requestId = 0;
            using (var cmd = eaSql.CreateDbCommandWriter(UPDATE_AZ_DOC_REL_REQUEST, CommandType.StoredProcedure)) {
				cmd.AddInParam("PI_DOC_ID", DbType.Int32, ent.DocId);
				cmd.AddInParam("PI_TYPE_ID", DbType.Int32, ent.TypeId);
				cmd.AddInParam("PI_SUBTYPE_ID", DbType.Int32, ent.SubtypeId);
				cmd.AddInParam("PI_PROPERTY_TYPE_ID", DbType.Int32, ent.PropertyTypeId);
				cmd.AddInParam("PI_APPROVAL_ID", DbType.Int32, ent.ApprovalId);
				cmd.AddInParam("PI_COMMENTS", DbType.String, ent.Comments);
				cmd.AddInParam("PI_STATUS_ID", DbType.Int32, ent.StatusId);
				cmd.AddInParam("PI_REASON_TXT", DbType.String, ent.ReasonTxt);
				cmd.AddInParam("PI_DOCUMENT_ID", DbType.Int32, ent.DocumentId);
				cmd.AddInParam("PI_REQUEST_DTM", DbType.DateTime, ent.RequestDtm);
				cmd.AddInParam("PI_EXPIRATION_DTM", DbType.DateTime, ent.ExpirationDtm);
				cmd.AddInParam("PI_PENDING_NOTIFICATION", DbType.StringFixedLength, ent.PendingNotification.ToChar());
				cmd.AddInParam("PI_UPDT_USERID", DbType.Int32, ent.UpdtUserid);
				cmd.AddInParam("PI_UPDT_DTM", DbType.DateTime, ent.UpdtDtm);
				cmd.AddInParam("PI_CHANGE_ID", DbType.Int32, ent.ChangeId);
                cmd.AddOutParam("PO_REQUEST_ID", DbType.Int32, 4);
                helper.ExecuteNonQuery(cmd);
                requestId = Convert.ToInt32(cmd.GetParamValue("PO_REQUEST_ID").ToString());
            }
            return requestId;
        }

        public List<AzDocRelRequestEntity> GetAllAzDocRelRequest(Int32 docId)
        {
            var list = new List<AzDocRelRequestEntity>();
            using (var cmd = eaSql.CreateDbCommandWriter(GET_ALL_AZ_DOC_REL_REQUEST, CommandType.StoredProcedure))
            {
                cmd.AddInParam("PI_DOC_ID", DbType.Int32, docId);
                using (var ds = new DataSet())
                {
                    helper.LoadDataSet(cmd, ds, "Results");
                    DataTable dt = ds.Tables["Results"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        var item = new AzDocRelRequestEntity();
                        item.MapFromRow(dr);
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        
        public void DeleteAzDocRelRequest(Int32 requestId)
        {
            using (var cmd = eaSql.CreateDbCommandWriter(DELETE_AZ_DOC_REL_REQUEST, CommandType.StoredProcedure))
            {
                cmd.AddInParam("PI_REQUEST_ID", DbType.Int32, requestId);
                helper.ExecuteNonQuery(cmd);
            }
        }
    }
}