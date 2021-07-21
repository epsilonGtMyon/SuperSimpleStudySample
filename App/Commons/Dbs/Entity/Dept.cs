namespace SuperSimpleStudySample.App.Commons.Dbs.Entity
{
    public class Dept
    {
        public string DeptCode { get; set; }

        public string DeptName { get; set; }

        public string Address { get; set; }


        public override string ToString() {
            return $"Dept[DeptCode={DeptCode}, DeptName={DeptName}, Address={Address}]";
        }
        
    }
}