using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Model.Context;
using System.Linq;

namespace RestWithASPNETudemy.Repository.Implementations
{
    public class AppAgendaCDRepositoryImplementation : IAppAgendaCDRepository
    {
        private MySQLContext _context;

        public AppAgendaCDRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<AppAgendaCD> FindAll()
        {
            List<AppAgendaCD> Agenda = new List<AppAgendaCD>();

            return _context.Agenda.ToList();
        }

        public AppAgendaCD FindById(long id)
        {
            return _context.Agenda.SingleOrDefault(p => p.AGD_ID.Equals(id));
        }

        public AppAgendaCD Create(AppAgendaCD agendaCD)
        {
            try
            {
                _context.Add(agendaCD);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return agendaCD;
        }

        public AppAgendaCD Update(AppAgendaCD agendaCD)
        {
            if (!Exists(agendaCD.AGD_ID)) return null;

            var result = _context.Agenda.SingleOrDefault(p => p.AGD_ID.Equals(agendaCD.AGD_ID));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(agendaCD);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return agendaCD;
        }
        public bool Exists(long id)
        {
            return _context.Agenda.Any(p => p.AGD_ID.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Agenda.SingleOrDefault(p => p.AGD_ID.Equals(id));

            try
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
