import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryBrowserComponent } from './story-browser.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PaginatorComponent } from '../shared/paginator/paginator.component';

describe('StoryBrowserComponent', () => {
  let component: StoryBrowserComponent;
  let fixture: ComponentFixture<StoryBrowserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoryBrowserComponent, PaginatorComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoryBrowserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(StoryBrowserComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h2')?.textContent).toContain('Newest Stories');
  });
});
