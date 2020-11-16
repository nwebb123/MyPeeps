using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPeeps.Data;
using MyPeeps.Models;

namespace MyPeeps.Controllers
{
    public class MPContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MPContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MPContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MPContact.ToListAsync());
        }

        // GET: MPContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPContact = await _context.MPContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mPContact == null)
            {
                return NotFound();
            }

            return View(mPContact);
        }

        // GET: MPContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MPContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,ImagePath,ImageData,Address1,Address2,City,State,ZipCode,Phone,Created")] MPContact mPContact)
        {
            if (ModelState.IsValid)
            {
                mPContact.Created = DateTime.Now;

                // Use this to upload profile pic in create? Is that what Avatar is? 

                //if (attachment != null)
                //{
                //    AttachmentHandler attachmentHandler = new AttachmentHandler();
                //    ticket.Attachments.Add(attachmentHandler.Attach(attachment));
                //}




                _context.Add(mPContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mPContact);
        }

        // GET: MPContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPContact = await _context.MPContact.FindAsync(id);
            if (mPContact == null)
            {
                return NotFound();
            }
            return View(mPContact);
        }

        // POST: MPContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,ImagePath,ImageData,Address1,Address2,City,State,ZipCode,Phone,Created")] MPContact mPContact)
        {
            if (id != mPContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mPContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MPContactExists(mPContact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mPContact);
        }

        // GET: MPContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPContact = await _context.MPContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mPContact == null)
            {
                return NotFound();
            }

            return View(mPContact);
        }

        // POST: MPContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mPContact = await _context.MPContact.FindAsync(id);
            _context.MPContact.Remove(mPContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MPContactExists(int id)
        {
            return _context.MPContact.Any(e => e.Id == id);
        }
    }
}
