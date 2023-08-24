namespace MK.WebUIMVC.Models
{
    public class ResponseComing<T>
    {
        public List<T> data { get; set; }
        public List<string> errorMaessage { get; set; }
        public List<string> succesMessage { get; set; }
    }
}
