using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ServicesV7.DBModels;
using ServicesV7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesV7.Classes
{
    public class FilmService
    {
        FilmlerContext _context;
        public FilmService()
        {
            _context = new FilmlerContext();
        }

        public List<FilmVM> getFilmVMList() 
        {
            //_context = new FilmlerContext();
            var result=new List<FilmVM>();
            var list = _context.Films.Include(a => a.FilmTypeNavigation).ToList();
            foreach (var item in list)
            {
                FilmVM vm = new FilmVM();
                vm.FilmId = item.FilmId;
                vm.FilmName = item.FilmName;
                vm.FilmProduction = item.FilmProduction;
                //vm.FilmType = item.FilmType;
                vm.FilmImdb = item.FilmImdb;
                vm.FilmDescription = item.FilmTypeNavigation.TypeName;
                vm.FilmTime = item.FilmTime;
                vm.FilmExplanation = item.FilmExplanation;
                vm.FilmResimLinki = item.FilmResimLinki;
                result.Add(vm);
            }
             return result;
        }
        public FilmVM_CE GetFilmVM_CE() 
        {
            //_context = new FilmlerContext();
            var result = new FilmVM_CE();

            result.TypeList=_context.Types.ToList();

            return result;
        }
        public void SaveFilm(FilmVM_CE vm)
        {
            //_context = new FilmlerContext();
            var model = new Film();
            model.FilmName = vm.FilmName;
            model.FilmProduction=vm.FilmProduction;
            model.FilmType = vm.FilmType;
            model.FilmTime=vm.FilmTime;
            model.FilmImdb = vm.FilmImdb;
            model.FilmExplanation=vm.FilmExplanation;
            model.FilmResimLinki = vm.FilmResimLinki;

            _context.Films.Add(model);
            _context.SaveChanges();
        }

        public bool DeleteFilm(int id)
        {
            var model = _context.Films.Find(id);
            if (model == null) 
            {
                return false;
            }
            _context.Films.Remove(model);
            _context.SaveChanges(true);
            return true;
        }
        public FilmVM_CE GetFilmVMEdit_CE(int id)
        {

            var model = _context.Films.Find(id);
            var result = new FilmVM_CE();

            result.TypeList = _context.Types.Where(x => x.TypeId > 0).ToList();
            result.FilmId = model.FilmId;
            result.FilmName = model.FilmName;
            result.FilmProduction = model.FilmProduction;
            result.FilmType = model.FilmType;
            result.FilmTime = model.FilmTime;
            result.FilmImdb = model.FilmImdb;
            result.FilmExplanation = model.FilmExplanation;
            result.FilmResimLinki = model.FilmResimLinki;
            

            return result;
        }
        public void EditFilm(FilmVM_CE vm)
        {

            var model = _context.Films.Find(vm.FilmId);
            model.FilmId = vm.FilmId;
            model.FilmName = vm.FilmName;
            model.FilmProduction = vm.FilmProduction;
            model.FilmType = vm.FilmType;
            model.FilmTime = vm.FilmTime;
            model.FilmImdb = vm.FilmImdb;
            model.FilmExplanation = vm.FilmExplanation;
            model.FilmResimLinki= vm.FilmResimLinki;

            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public Dictionary<string, List<FilmVM>> GetFilmsByCategory()
        {
            var result = new Dictionary<string, List<FilmVM>>();

            var filmTypes = _context.Types.ToList();

            foreach (var filmType in filmTypes)
            {
                var category = filmType.TypeName;

                var films = _context.Films
                    .Where(f => f.FilmType == filmType.TypeId)
                    .Select(f => new FilmVM
                    {
                        FilmId = f.FilmId,
                        FilmName = f.FilmName,
                        FilmProduction = f.FilmProduction,
                        FilmImdb = f.FilmImdb,
                        FilmDescription = f.FilmTypeNavigation.TypeName,
                        FilmTime = f.FilmTime,
                        FilmExplanation = f.FilmExplanation,
                        FilmResimLinki = f.FilmResimLinki
                    })
                    .ToList();

                result[category] = films;
            }

            return result;
        }






    }

}

