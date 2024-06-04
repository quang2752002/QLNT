import { Component, OnInit } from '@angular/core';
import { Nghiatrang } from 'src/app/shared/model/nghiatrang/nghiatrang';
import { NghiatrangService } from 'src/app/shared/service/nghiatrang/nghiatrang.service';

@Component({
  selector: 'app-nghiatrang-list',
  templateUrl: './nghiatrang-list.component.html',
  styleUrls: ['./nghiatrang-list.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class NghiatrangListComponent implements OnInit {
  list: Nghiatrang[] = [];
  page: number = 1; // Current page number
  itemsPerPage: number = 10; // Items per page
  totalItems: number = 0; // Total number of items

  constructor(public service: NghiatrangService) {}

  ngOnInit(): void {
    this.loadList();
  }

  loadList(): void {
    this.service.refreshList().subscribe(res => {
      this.list = res;
      this.totalItems = res.length; // Update total items count
    });
  }

  onDelete(id: number): void {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteNghiaTrang(id).subscribe(res => {
        this.page = 1; // Reset to the first page
        this.loadList(); // Refresh list after deletion
      });
    }
  }

  // Method to get the range of page numbers to display
  getPaginationRange(): number[] {
    const start = Math.max(this.page - 1, 1);
    const end = Math.min(this.page + 1, Math.ceil(this.totalItems / this.itemsPerPage));
    return Array(end - start + 1).fill(0).map((_, i) => i + start);
  }

  // Method to check if the next button should be disabled
  isLastPage(): boolean {
    return this.page === Math.ceil(this.totalItems / this.itemsPerPage);
  }

  // Method to navigate to the first page
  goToFirstPage() {
    this.page = 1;
  }

  // Method to navigate to the last page
  goToLastPage() {
    this.page = Math.ceil(this.totalItems / this.itemsPerPage);
  }
}
