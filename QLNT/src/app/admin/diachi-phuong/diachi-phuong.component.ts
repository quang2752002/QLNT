import { Component, OnInit } from '@angular/core';
import { Diachi } from 'src/app/shared/model/diachi/diachi';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-diachi-phuong',
  templateUrl: './diachi-phuong.component.html',
  styleUrls: ['./diachi-phuong.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class DiachiPhuongComponent implements OnInit {
  id: number = 0;
  list: Diachi[] = [];
  page: number = 1;
  itemsPerPage: number = 10;
  totalItems: number = 0;

  constructor(public service: DiachiService,private _router: ActivatedRoute) {}

  ngOnInit(): void {
    this.id = this._router.snapshot.params.id;
    console.log(this.id);
    this.service.getDiaChiChild(this.id).subscribe(res => {
      this.list = res;
      this.totalItems = res.length; // Set total items here
    });
    
  }
  loadList(): void {
    this.id = this._router.snapshot.params.id;
    this.service.getDiaChiChild(this.id).subscribe(res => {
      this.list = res;
      this.totalItems = res.length; // Update total items count
    });
  }
  onDelete(id: number): void {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteDiaChi(id).subscribe(res => {
        this.page = 1; // Reset to the first page
        this.loadList(); // Refresh list after deletion
      });
    }
  }
  getPaginationRange(): number[] {
    const start = Math.max(this.page - 1, 1);
    const end = Math.min(this.page + 1, Math.ceil(this.totalItems / this.itemsPerPage));
    return Array(end - start + 1).fill(0).map((_, i) => i + start);
  }

  isLastPage(): boolean {
    return this.page === Math.ceil(this.totalItems / this.itemsPerPage);
  }

  goToFirstPage() {
    this.page = 1;
  }

  goToLastPage() {
    this.page = Math.ceil(this.totalItems / this.itemsPerPage);
  }
}

