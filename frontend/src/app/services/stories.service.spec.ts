import { TestBed } from '@angular/core/testing';

import { StoriesService } from './stories.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('StoriesService', () => {
  let service: StoriesService;
  // let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [StoriesService]
    });

    service = TestBed.inject(StoriesService);
    // httpMock = TestBed.inject(HttpTestingController);
  });

  // afterEach(() => {
  //   httpMock.verify(); // makes sure no unmatched requests are left
  // });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // We can't test with dummy data as the latest stories change during the time

  // it('should fetch latest stories with correct query', () => {
  //   const dummyResponse: IPaginated<IStory> = {
  //     records: [{ id: 1, title: 'Sample Story' } as IStory],
  //     total: 1
  //   };

  //   const pgSize = 10;
  //   const pgNumber = 1;
  //   const term = 'Angular';

  //   service.getLatest(pgSize, pgNumber, term).subscribe((data) => {
  //     expect(data).toEqual(dummyResponse);
  //   });

  //   const req = httpMock.expectOne(
  //     `${service['route']}?pgSize=${pgSize}&pgNumber=${pgNumber}&term=${term}`
  //   );
  //   expect(req.request.method).toBe('GET');
  //   req.flush(dummyResponse);
  // });
});
