namespace PrisonersActivity.BE
{
    internal record ZSettings
    {
        public decimal DayAmount { get; set; }
        public string PrisonName { get; set; }
        public string Footer1 { get; set; }
        public string Footer2 { get; set; }
        public string Footer3 { get; set; }
        public string Footer4 { get; set; }
        public string Footer1Teir { get; set; }
        public string Footer2Teir { get; set; }
        public string Footer3Teir { get; set; }
        public string Footer4Teir { get; set; }
        public string ReportHeader { get; set; }
        public bool CanRepeatCompNum { get; set; }
    }
}
