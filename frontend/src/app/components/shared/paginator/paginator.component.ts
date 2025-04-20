import { Component, EventEmitter, input, Input, Output } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrl: './paginator.component.scss'
})
export class PaginatorComponent {

  _currentPage: number = 1;
  _totalPages: number = 0;
  _pageSize: number = 20;
  _totalRecords: number = 0;

  pages: number[] = [];

  @Output() pgSelectEvent = new EventEmitter();

  get pageSize() { return this._pageSize; }
  get totalPages() { return Math.ceil(this._totalRecords / this._pageSize); }
  get currentPage() { return this._currentPage; }

  @Input("itemsPerPage")
  set itemsPerPage(value: number) {
    this._pageSize = value;
    this.updatePages();
  }

  @Input("dataSource")
  set dataSource(items: any[]) {
    this._totalRecords = items.length;
    this.updatePages();
  }

  @Input("totalRecords")
  set totalRecords(total: number) {
    this._totalRecords = total;
    this.updatePages();
  }


  updatePages() {
    const pagesToShow = 5;
    const half = Math.floor(pagesToShow / 2);
    let start = Math.max(this.currentPage - half, 1);
    let end = start + pagesToShow - 1;
  
    if (end > this.totalPages) {
      end = this.totalPages;
      start = Math.max(end - pagesToShow + 1, 1);
    }
  
    this.pages = [];
    for (let i = start; i <= end; i++) {
      this.pages.push(i);
    }
  }
  
  goToPrevious() {
    if (this.currentPage > 1) {
      this._currentPage--;
      this.pgSelectEvent.emit(this._currentPage);
      this.updatePages();
    }
  }
  
  goToNext() {
    if (this.currentPage < this.totalPages) {
      this._currentPage++;
      this.pgSelectEvent.emit(this._currentPage);
      this.updatePages();
    }
  }
  
  goToPage(page: number) {
    if (page !== this.currentPage) {
      this._currentPage = page;
      this.pgSelectEvent.emit(this._currentPage);
      this.updatePages();
    }
  }
}
