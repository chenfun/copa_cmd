using System;
using System.Collections.Generic;

namespace CopaCmd.AttnErp.Models
{
    public partial class MfMo
    {
        public string MoNo { get; set; } = null!;
        public DateTime MoDd { get; set; }
        public DateTime StaDd { get; set; }
        public DateTime EndDd { get; set; }
        public string? BilId { get; set; }
        public string? BilNo { get; set; }
        public string? MrpNo { get; set; }
        public string? PrdMark { get; set; }
        public string? Wh { get; set; }
        public string? SoNo { get; set; }
        public string? Unit { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Qty1 { get; set; }
        public DateTime NeedDd { get; set; }
        public string? Dep { get; set; }
        public string? CusNo { get; set; }
        public string? CloseId { get; set; }
        public string? Usr { get; set; }
        public string? ChkMan { get; set; }
        public string? BatNo { get; set; }
        public string? Rem { get; set; }
        public string? PoOk { get; set; }
        public string? MoNoAdd { get; set; }
        public decimal? QtyFin { get; set; }
        public decimal? QtyFinUnsh { get; set; }
        public decimal? TimeAj { get; set; }
        public decimal? QtyMl { get; set; }
        public decimal? QtyMlUnsh { get; set; }
        public string? BuildBil { get; set; }
        public decimal? CstMake { get; set; }
        public decimal? CstPrd { get; set; }
        public decimal? CstOut { get; set; }
        public decimal? CstMan { get; set; }
        public decimal? UsedTime { get; set; }
        public decimal? Cst { get; set; }
        public string? PrtSw { get; set; }
        public DateTime? OpnDd { get; set; }
        public DateTime? FinDd { get; set; }
        public string? BilMak { get; set; }
        public string? CpySw { get; set; }
        public string? Contract { get; set; }
        public int? EstItm { get; set; }
        public string? MlOk { get; set; }
        public string? MdNo { get; set; }
        public decimal? QtyRk { get; set; }
        public decimal? QtyRkUnsh { get; set; }
        public DateTime? ClsDate { get; set; }
        public string? IdNo { get; set; }
        public decimal? QtyChk { get; set; }
        public string? Control { get; set; }
        public string? Isnormal { get; set; }
        public string? QcYn { get; set; }
        public string? MmCurml { get; set; }
        public string? TsId { get; set; }
        public string? BilType { get; set; }
        public string? CnttNo { get; set; }
        public string? MobId { get; set; }
        public string? LockMan { get; set; }
        public DateTime? LockDate { get; set; }
        public string? SebNo { get; set; }
        public string? GrpNo { get; set; }
        public DateTime? OutDdMoj { get; set; }
        public DateTime? SysDate { get; set; }
        public string? PgId { get; set; }
        public string? SupPrdNo { get; set; }
        public decimal? TimeCnt { get; set; }
        public string? MlByMm { get; set; }
        public string? CasNo { get; set; }
        public int? TaskId { get; set; }
        public string? OldId { get; set; }
        public string? CfId { get; set; }
        public string? CusOsNo { get; set; }
        public string? PrtUsr { get; set; }
        public decimal? QtyQl { get; set; }
        public decimal? QtyQlUnsh { get; set; }
        public string? QlId { get; set; }
        public string? Q2Id { get; set; }
        public string? Q3Id { get; set; }
        public string? Issvs { get; set; }
        public decimal? QtyDm { get; set; }
        public decimal? QtyDmUnsh { get; set; }
        public string? Lock { get; set; }
        public decimal? QtyLost { get; set; }
        public decimal? QtyLostUnsh { get; set; }
        public string? Isfromqd { get; set; }
        public string? ZtId { get; set; }
        public DateTime? ZtDd { get; set; }
        public string? CvId { get; set; }
        public string? CuNo { get; set; }
        public decimal? QtyChkUnsh { get; set; }
        public string? CancelId { get; set; }
        public string? SupPrdMark { get; set; }
        public DateTime? PrtDate { get; set; }
        public string? BjNo { get; set; }
        public DateTime? ModifyDd { get; set; }
        public string? ModifyMan { get; set; }
        public int? DecUn { get; set; }
        public decimal? QtyQs { get; set; }
        public decimal? QtyQsUnsh { get; set; }
        public string? BackId { get; set; }
        public decimal? QtyPg { get; set; }
        public decimal? QtyPgUnsh { get; set; }
        public string? SoId { get; set; }
        public string? Ismatchbil { get; set; }
        public DateTime? CfDd { get; set; }
        public int? MesStatus { get; set; }
        public string? AppNameData { get; set; }
        public string? Qcmlflag { get; set; }
        public decimal? QtyEr { get; set; }
        public decimal? QtyErUnsh { get; set; }
        public int? BilItm { get; set; }
        public decimal? CstManMl { get; set; }
        public decimal? CstMakMl { get; set; }
        public decimal? CstPrdMl { get; set; }
        public decimal? CstOutMl { get; set; }
        public decimal? CstMl { get; set; }
        
        public ICollection<MfTz> MfTzs { get; set; } = new List<MfTz>();

    }
}
