using System;
using System.Data;

namespace Entities
{
    public class RelDietEntity : BaseEntity
    {
        public Int32 RequestId { get; set; }
        public Int32 TypeId { get; set; }
        public String ReasonTxt { get; set; }
        public String SupportTxt { get; set; }
        public String MenuTxt { get; set; }
        public Int32 InmateSignatureId { get; set; }
        public Int32 OtherSignatureId { get; set; }
        public DateTime InterviewDtm { get; set; }
        public Int32 DecisionId { get; set; }
        public DateTime DecisionDtm { get; set; }
        public Boolean FslRejectFlag { get; set; }
        public Int32 UpdtUserid { get; set; }
        public DateTime UpdtDtm { get; set; }
        public Boolean ActiveFlag { get; set; }
        
        public RelDietEntity() : base(){}

        public RelDietEntity(IDataRecord dataRecord) : base (dataRecord)
        {
            RequestId = (int)dataRecord["REQUEST_ID"];
            TypeId = (int)dataRecord["TYPE_ID"];
            ReasonTxt = (string)dataRecord["REASON_TXT"];
            SupportTxt = (string)dataRecord["SUPPORT_TXT"];
            MenuTxt = (string)dataRecord["MENU_TXT"];
            //InmateSignatureId = (int)dataRecord["INMATE_SIGNATURE_ID"];
            //OtherSignatureId = (int)dataRecord["OTHER_SIGNATURE_ID"];
            InterviewDtm = (DateTime)dataRecord["INTERVIEW_DTM"];
            //DecisionId = (int)dataRecord["DECISION_ID"];
            //DecisionDtm = (DateTime)dataRecord["DECISION_DTM"];
            //FslRejectFlag = (bool)dataRecord["FSL_REJECT_FLAG"];
            //UpdtUserid = (int)dataRecord["UPDT_USERID"];
            //UpdtDtm = (DateTime)dataRecord["UPDT_DTM"];
            //ActiveFlag = (bool)dataRecord["ACTIVE_FLAG"];
        }
    }
}