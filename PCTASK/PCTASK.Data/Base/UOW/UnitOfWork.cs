namespace PCTASK.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;

        public UnitOfWork(ProductContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}