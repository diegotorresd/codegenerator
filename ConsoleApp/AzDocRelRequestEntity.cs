using System;
using System.Text;
using System.Data;

namespace MD_MiCASE_DOC_Entities
{
	public class AzDocRelRequestEntity : BaseEntity
	{
		public Int32 RequestId;
		public Int32 DocId;
		public Int32 TypeId;
		public Int32 SubtypeId;
		public Int32 PropertyTypeId;
		public Int32 ApprovalId;
		public String Comments;
		public Int32 StatusId;
		public String ReasonTxt;
		public Int32 DocumentId;
		public DateTime RequestDtm;
		public DateTime ExpirationDtm;
		public Boolean PendingNotification;
		public Int32 UpdtUserid;
		public DateTime UpdtDtm;
		public Boolean ActiveFlag;
		public Int32 ChangeId;

		public override void MapFromRow(DataRow dr) {
			if (dr.Table.Columns.Contains("REQUEST_ID"))
				RequestId = dr["REQUEST_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("DOC_ID"))
				DocId = dr["DOC_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("TYPE_ID"))
				TypeId = dr["TYPE_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("SUBTYPE_ID"))
				SubtypeId = dr["SUBTYPE_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("PROPERTY_TYPE_ID"))
				PropertyTypeId = dr["PROPERTY_TYPE_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("APPROVAL_ID"))
				ApprovalId = dr["APPROVAL_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("COMMENTS"))
				Comments = dr["COMMENTS"].DrToString();
			if (dr.Table.Columns.Contains("STATUS_ID"))
				StatusId = dr["STATUS_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("REASON_TXT"))
				ReasonTxt = dr["REASON_TXT"].DrToString();
			if (dr.Table.Columns.Contains("DOCUMENT_ID"))
				DocumentId = dr["DOCUMENT_ID"].DrToInt32();
			if (dr.Table.Columns.Contains("REQUEST_DTM"))
				RequestDtm = dr["REQUEST_DTM"].DrToDateTime();
			if (dr.Table.Columns.Contains("EXPIRATION_DTM"))
				ExpirationDtm = dr["EXPIRATION_DTM"].DrToDateTime();
			if (dr.Table.Columns.Contains("PENDING_NOTIFICATION"))
				PendingNotification = dr["PENDING_NOTIFICATION"].DrToBoolean();
			if (dr.Table.Columns.Contains("UPDT_USERID"))
				UpdtUserid = dr["UPDT_USERID"].DrToInt32();
			if (dr.Table.Columns.Contains("UPDT_DTM"))
				UpdtDtm = dr["UPDT_DTM"].DrToDateTime();
			if (dr.Table.Columns.Contains("ACTIVE_FLAG"))
				ActiveFlag = dr["ACTIVE_FLAG"].DrToBoolean();
			if (dr.Table.Columns.Contains("CHANGE_ID"))
				ChangeId = dr["CHANGE_ID"].DrToInt32();
		}
	}
}