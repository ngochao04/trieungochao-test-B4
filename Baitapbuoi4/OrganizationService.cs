using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Baitapbuoi4
{
    public class OrganizationService
    {
        private readonly OrganizationRepository _repo;

        public OrganizationService()
        {
            _repo = new OrganizationRepository();
        }

        // Validate theo mục 3.2
        public void Validate(Organization org)
        {
            if (string.IsNullOrWhiteSpace(org.OrgName))
                throw new Exception("Organization Name is required");

            if (org.OrgName.Length < 3)
                throw new Exception("Organization Name must be at least 3 characters");

            if (!string.IsNullOrWhiteSpace(org.Phone))
            {
                if (!Regex.IsMatch(org.Phone, @"^\d{9,12}$"))
                    throw new Exception("Phone must contain 9–12 digits");
            }

            if (!string.IsNullOrWhiteSpace(org.Email))
            {
                if (!Regex.IsMatch(org.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Exception("Invalid Email format");
            }
        }

        // Save Organization
        public void Save(Organization org)
        {
            Validate(org);

            if (_repo.IsOrgNameExists(org.OrgName))
                throw new Exception("Organization Name already exists");

            org.CreatedDate = DateTime.Now;
            _repo.Insert(org);
        }
    }
}
