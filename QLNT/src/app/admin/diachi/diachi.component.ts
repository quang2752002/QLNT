import { Component, OnInit } from '@angular/core';
import { Diachi } from 'src/app/shared/model/diachi/diachi';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';

@Component({
  selector: 'app-diachi',
  templateUrl: './diachi.component.html',
  styleUrls: [
    './diachi.component.css',
    '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
    '../../../assets/Themes2/css/sb-admin-2.min.css'
  ]
})
export class DiachiComponent implements OnInit {
  list: Diachi[] = [];
  page: number = 1;
  itemsPerPage: number = 10;
  totalItems: number = 0;

  constructor(public service: DiachiService) {}

  ngOnInit(): void {
    this.service.refreshList().subscribe(res => {
      this.list = res;
      this.totalItems = res.length; // Set total items here
    });
  }
  loadList(): void {
    this.service.refreshList().subscribe(res => {
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
