using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CopaCmd.AttnErp.Models
{
    public partial class MfTz
    {
        public string TzNo { get; set; } = null!;
        public DateTime TzDd { get; set; }
        public string? MoNo { get; set; }
        public string? MrpNo { get; set; }
        public string? PrdMark { get; set; }
        public string? Unit { get; set; }
        public decimal? Qty { get; set; }
        public string? CloseId { get; set; }
        public string? ZcNo { get; set; }
        public string? Rem { get; set; }
        public DateTime? StaDd { get; set; }
        public DateTime? EndDd { get; set; }
        public string? DepUp { get; set; }
        public string? DepDown { get; set; }
        public decimal? QtyFin { get; set; }
        public string? BilId { get; set; }
        public string? BilNo { get; set; }
        public string? Dep { get; set; }
        public string? BatNo { get; set; }
        public string? SoNo { get; set; }
        public decimal? QtyMl { get; set; }
        public decimal? QtyMlUnsh { get; set; }
        public DateTime? OpnDd { get; set; }
        public DateTime? FinDd { get; set; }
        public string? CpySw { get; set; }
        public string? Rrem { get; set; }
        public string? MlOk { get; set; }
        public string? Usr { get; set; }
        public string? ChkMan { get; set; }
        public string? PrtSw { get; set; }
        public string? MdNo { get; set; }
        public string? TrNo { get; set; }
        public int? ZcItm { get; set; }
        public string? ChkId { get; set; }
        public string? MvId { get; set; }
        public decimal? QtyPrc { get; set; }
        public decimal? QtyChk { get; set; }
        public decimal? QtyMv { get; set; }
        public decimal? QtyMvUnsh { get; set; }
        public decimal? QtyLost { get; set; }
        public string? ZcNoUp { get; set; }
        public string? ZcNoDn { get; set; }
        public decimal? QtyWh { get; set; }
        public string? IdNo { get; set; }
        public decimal? QtyRk { get; set; }
        public decimal? QtyRkUnsh { get; set; }
        public DateTime? ClsDate { get; set; }
        public decimal? CstMake { get; set; }
        public decimal? CstPrd { get; set; }
        public decimal? CstOut { get; set; }
        public decimal? CstMan { get; set; }
        public decimal? UsedTime { get; set; }
        public decimal? Cst { get; set; }
        public decimal? TimeCnt { get; set; }
        public string? QcYn { get; set; }
        public string? TsId { get; set; }
        public decimal? Qty1 { get; set; }
        public string? Isfirst { get; set; }
        public string? BilType { get; set; }
        public int? EstItm { get; set; }
        public string? MobId { get; set; }
        public string? LockMan { get; set; }
        public DateTime? LockDate { get; set; }
        public string? SebNo { get; set; }
        public string? GrpNo { get; set; }
        public DateTime? OutDdMoj { get; set; }
        public DateTime? SysDate { get; set; }
        public string? PgId { get; set; }
        public DateTime? MvDd { get; set; }
        public string? CasNo { get; set; }
        public int? TaskId { get; set; }
        public string? CusOsNo { get; set; }
        public string? PrtUsr { get; set; }
        public decimal? QtyQl { get; set; }
        public decimal? QtyQlUnsh { get; set; }
        public decimal? QtyDm { get; set; }
        public decimal? QtyDmUnsh { get; set; }
        public string? Lock { get; set; }
        public string? MlFin { get; set; }
        public string? ZtId { get; set; }
        public DateTime? ZtDd { get; set; }
        public decimal? QtyChkUnsh { get; set; }
        public decimal? QtyLostUnsh { get; set; }
        public string? Chkqcsj { get; set; }
        public string? CancelId { get; set; }
        public DateTime? PrtDate { get; set; }
        public DateTime? ModifyDd { get; set; }
        public string? ModifyMan { get; set; }
        public decimal? QtyLostSzc { get; set; }
        public decimal? QtyLostZc { get; set; }
        public decimal? QtyLostSzcUnsh { get; set; }
        public decimal? QtyLostZcUnsh { get; set; }
        public decimal? QtyQs { get; set; }
        public decimal? QtyQsUnsh { get; set; }
        public string? BackId { get; set; }
        public string? SoId { get; set; }
        public string? LbChk { get; set; }
        public string? BatPgNo { get; set; }
        public decimal? QtyFinUnsh { get; set; }
        public string? AppNameData { get; set; }
        public string? Qcmlflag { get; set; }
        public decimal? CstManMl { get; set; }
        public decimal? CstMakMl { get; set; }
        public decimal? CstPrdMl { get; set; }
        public decimal? CstOutMl { get; set; }
        public decimal? CstMl { get; set; }

        [JsonIgnore]
        public MfMo MfMo { get; set; } = null!;
    }
}
