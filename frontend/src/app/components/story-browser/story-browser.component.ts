import { Component, OnInit } from '@angular/core';
import { StoriesService } from '../../services/stories.service';
import { IStory } from '../../models/interfaces/story.model';

@Component({
  selector: 'app-story-browser',
  templateUrl: './story-browser.component.html',
  styleUrl: './story-browser.component.scss'
})
export class StoryBrowserComponent implements OnInit {
  
  pgSize: number = 20;
  pgNumber: number = 1;
  records: Array<IStory> = [];

  constructor(private _storiesService: StoriesService) { }
  
  ngOnInit(): void {
    this.getLatest();
  }

  getLatest() {
    this._storiesService.getLatest(this.pgSize, this.pgNumber)
      .subscribe(x => this.records = x);
  }

  search(elem: HTMLInputElement) {
    if(elem.value.length)
      this._storiesService.getLatest(this.pgSize, 1, elem.value).subscribe(x => this.records = x);
    else this.getLatest();
  }


  toDate(epoch: number): string {
    const date = new Date(epoch * 1000);
    return date.toLocaleString("en-US");
  }
}
