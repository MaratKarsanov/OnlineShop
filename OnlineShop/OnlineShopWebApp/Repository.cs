using Microsoft.Extensions.Hosting;
using System.Text;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class Repository<T> : IEnumerable<T>
        where T : RepositoryItem
    {
        private List<T> Elements;
        public int Count { get { return Elements.Count; } }

        public Repository()
        {
            Elements = new List<T>();
        }

        public Repository(List<T> elements)
        {
            Elements = elements;
        }

        public T TryGetElementById(Guid id)
        {
            return Elements.FirstOrDefault(e => e.Id == id);
        }

        public T Add(T element)
        {
            if (TryGetElementById(element.Id) is null)
                Elements.Add(element);
            return element;
        }

        public void Remove(T element)
        {
            Elements = Elements
                .Where(e => e.Id != element.Id)
                .ToList();
        }

        public bool Contains(T element)
        {
            return Elements.Contains(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Elements)
                yield return element;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var e in Elements)
                result.Append(e.ToString() + "\n\n");
            return result.ToString();
        }
    }
}
