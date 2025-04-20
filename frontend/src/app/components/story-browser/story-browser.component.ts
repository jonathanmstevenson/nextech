import { Component, OnInit } from '@angular/core';
import { StoriesService } from '../../services/stories.service';
import { IStory } from '../../models/interfaces/story.interface';
import { IPaginated } from '../../models/interfaces/paginator.interface';

@Component({
  selector: 'app-story-browser',
  templateUrl: './story-browser.component.html',
  styleUrl: './story-browser.component.scss'
})
export class StoryBrowserComponent implements OnInit {
  
  pgSize: number = 50;
  pgNumber: number = 1;
  dataSource?: IPaginated<IStory>;
  searchTerm?: string;

  constructor(private _storiesService: StoriesService) { }
  
  ngOnInit(): void {
    this.getLatest();
  }

  getLatest(term?: string) {
    this.searchTerm = term;
    this._storiesService.getLatest(this.pgSize, this.pgNumber, term)
      .subscribe(x => this.dataSource = x);
  }

  onPageChange(pg: number) {
    this.pgNumber = pg;
    this.getLatest(this.searchTerm);
  }


  toDate(epoch: number): string {
    const date = new Date(epoch * 1000);
    return date.toLocaleString("en-US");
  }
}
