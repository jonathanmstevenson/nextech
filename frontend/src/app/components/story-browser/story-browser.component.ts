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

}
