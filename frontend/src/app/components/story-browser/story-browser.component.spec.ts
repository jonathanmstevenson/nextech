import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryBrowserComponent } from './story-browser.component';

describe('StoryBrowserComponent', () => {
  let component: StoryBrowserComponent;
  let fixture: ComponentFixture<StoryBrowserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoryBrowserComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoryBrowserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
