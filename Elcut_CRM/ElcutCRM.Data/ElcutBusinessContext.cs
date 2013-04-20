using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElcutCRM.Data
{
    public class ElcutBusinessContext : IDisposable
    {
        protected ElcutContext _context;

        public ElcutBusinessContext()
        {
            _context = new ElcutContext();
        }

        private UserManager _userManager;

        public UserManager UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new UserManager(_context);
                }

                return _userManager;
            }
        }

        private OrderManager _orderManager;

        public OrderManager OrderManager
        {
            get
            {
                if (_orderManager == null)
                {
                    _orderManager = new OrderManager(_context);
                }

                return _orderManager;
            }
        }

        private OrganizationManager _organizationManager;

        public OrganizationManager OrganizationManager
        {
            get
            {
                if (_organizationManager == null)
                {
                    _organizationManager = new OrganizationManager(_context);
                }

                return _organizationManager;
            }
        }

        public GenericManager<T> GetGenericManagerInstance<T>() where T : class
        {
            return new GenericManager<T>(_context);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
