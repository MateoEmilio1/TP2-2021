using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public Plan GetOne(int ID)
        {

            return (PlanData.GetOne(ID));
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de PlanData
            PlanData.Delete(ID);
        }

        public void Update(Business.Entities.Plan plan)
        {
            PlanData.Update(plan);
        }

    }
}
