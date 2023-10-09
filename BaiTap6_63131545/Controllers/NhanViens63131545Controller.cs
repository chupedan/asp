using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTap6_63131545.Models;

namespace BaiTap6_63131545.Controllers
{
    public class NhanViens63131545Controller : Controller
    {
        private QLNV_63131545Entities db = new QLNV_63131545Entities();

        // GET: NhanViens63131545
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.PhongBan);
            return View(nhanViens.ToList()); // hien thi tat ca danh sach
        }

        // GET: NhanViens63131545/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id); // tim kiem
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens63131545/Create
        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB");
            return View();
        }

        // POST: NhanViens63131545/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,MaPB")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien); // them
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // GET: NhanViens63131545/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // POST: NhanViens63131545/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,MaPB")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges(); // luu lai
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // GET: NhanViens63131545/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens63131545/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
