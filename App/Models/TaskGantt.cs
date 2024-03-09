namespace App.Models
{
    public class TaskGantt
    {
        public string Id { get; set; }
        public string Name { get; set; } = "Departamento TESTE";
        public string Start { get; set; }
        public string End { get; set; }
        public int Progress { get; set; }
        public string Dependencies { get; set; }
        public string Custom_class { get; set; }
    }
}
