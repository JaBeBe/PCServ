import { TestBed } from '@angular/core/testing';
import { HttpService } from '../login/http.service';
import {
    HttpClientTestingModule,
    HttpTestingController
} from '@angular/common/http/testing';

describe('HttpService', () => {
    // We declare the variables that we'll use for the Test Controller and for our Service
    let httpTestingController: HttpTestingController;
    let service: HttpService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [HttpService],
            imports: [HttpClientTestingModule]
        });

        // We inject our service (which imports the HttpClient) and the Test Controller
        httpTestingController = TestBed.get(HttpTestingController);
        service = TestBed.get(HttpService);
    });

    afterEach(() => {
        httpTestingController.verify();
    });

    describe('addCourse()', () => {
        it('returned Observable should match the right data', () => {
            const mockCourse = {
                FirstName: "Stuart",
                LastName: "Little",
            };

            service.addUser({ userId: 1 })
                .subscribe(courseData => {
                    expect(courseData.FirstName).toEqual('Stuart');
                });

            const req = httpTestingController.expectOne('http://localhost:8089/topics/1');

            expect(req.request.method).toEqual('POST');

            req.flush(mockCourse);
        });
    });
    describe('getUsersById()', () => {
        it('returned Observable should match the right data', () => {
            const mockUsers = [
                {
                    FirstName: 'Alfred',
                    LastName: 'Batman'
                },
                {
                    FirstName: 'John',
                    LastName: 'Connor'
                }
            ];

            service.getUserById(1)
                .subscribe(userData => {
                    expect(userData[0].FirstName).toEqual('Alfred');
                    expect(userData[0].LastName).toEqual('Batman');

                    expect(userData[1].FirstName).toEqual('John');
                    expect(userData[1].LastName).toEqual('Connor');
                });

            const req = httpTestingController.expectOne(
                'http://localhost:8089/topics/1'
            );

            req.flush(mockUsers);
        });
    });
});
