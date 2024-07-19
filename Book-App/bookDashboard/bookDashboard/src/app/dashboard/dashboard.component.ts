import { Component, OnInit } from '@angular/core';
import {ApiListService} from '../api-list.service'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  books: any[] = [];
  loading: boolean = false;
  searchQuery: string = '';
  searchResults: any[] = [];
  searchBack: boolean = false;

  constructor(private apiListService: ApiListService) { }

  ngOnInit(): void {
    this.loadPopularBooks();
  }

  loadPopularBooks(): void {
    this.searchBack = false;
    this.loading = true;
    this.apiListService.getPopularBooks().subscribe(
      (data: any) => {
        this.loading = false;
        this.books = data; // Assuming `data` contains the list of books
      },
      (error: any) => {
        this.loading = false;
        this.books = []; // Clear books array to show "No books found" message
        console.error('Error loading popular books:', error);
      }
    );
  }

  goToDashboard(){
    this.loadPopularBooks();
  }

  getCoverImageUrl(coverId: number): string {
    return this.apiListService.getCoverImageUrl(coverId);
  }

  onSearch(): void {
    this.searchBack = true;
    if (this.searchQuery.trim()) {
      this.loading = true;
      this.apiListService.searchBooks(this.searchQuery).subscribe(response => {
        this.loading = false;
        this.searchResults = response.docs;
      });
    }
  }

}
