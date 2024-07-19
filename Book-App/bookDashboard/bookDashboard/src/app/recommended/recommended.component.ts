import { Component, OnInit } from '@angular/core';
import { ApiListService } from '../api-list.service';

@Component({
  selector: 'app-recommended',
  templateUrl: './recommended.component.html',
  styleUrls: ['./recommended.component.scss']
})
export class RecommendedComponent implements OnInit {

  recommendedBooks: any[] = [];
  loading: boolean = false;
  subject: string = 'thriller'; // Default subject
  limit: number = 12; // Default limit

  subjects: string[] = [
    'fiction', 
    'classics',
    'biography', 
    'romance', 
    'music',
    'dystoian',
    'mystery', 
    'horror',
    'history',
    'thriller',
    'Empowerment',
    'adventure',
    'poetry',
    'drama',
    'philosophy',
    'novel',
    'health',
    'travel',
    'sports',
    'comic'
    
  ];

  constructor(private apiListService: ApiListService) { }

  ngOnInit(): void {
    this.loadRecommendations();
  }

  loadRecommendations(): void {
    this.loading = true;
    this.apiListService.getRecommendations(this.subject, this.limit).subscribe((data: any) => {
      this.loading = false;
      this.recommendedBooks = data.works; // Adjust based on actual API response structure
    });
  }

  getCoverImageUrl(coverId: number): string {
    return this.apiListService.getCoverImageUrl(coverId);
  }

  onSubjectChange(newSubject: string): void {
    this.subject = newSubject;
    this.loadRecommendations();
  }

  onLimitChange(newLimit: number): void {
    if (newLimit < 1) {
      this.limit = 1;
    } else if (newLimit > 100) {
      this.limit = 100;
    } else {
      this.limit = newLimit;
    }
    this.loadRecommendations();
  }
}
