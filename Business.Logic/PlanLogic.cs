using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter planData;

        public PlanLogic()
        {
            planData = new PlanAdapter();
        }

        public Plan GetOne(int ID)
        {
            return planData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            return planData.GetAll();
        }

        public void Delete(int ID)
        {
            planData.Delete(ID);
        }

        public void Update(Plan plan)
        {
            planData.Update(plan);
        }

        public void Insert(Plan plan)
        {
            planData.Insert(plan);
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }

            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}