import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Company } from '../model/icompany';
import { HttpmethodService } from './httpmethod.service';

describe('HttpmethodService', () => {
  let service: HttpmethodService;
  let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy, put: jasmine.Spy, delete: jasmine.Spy };


  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post', 'delete', 'put'])
    service = new HttpmethodService(<any>httpClientSpy);
  });


  // getAll() function of company
  it(`getAll() function`, (done) => {
    const company = new Company(1, 'gtl@thegatewaycorp.com', 'Gateway Group of Companies', 10000, 'Ahmedabad', true, 3);
    httpClientSpy.get.and.returnValue(of([company]));
    service.getAll().subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    })
  });

  //get a particular company by id
  it('should return company based on id provided using done', (done)=>{
    //Arrange
    const company = new Company(1, 'gtl@thegatewaycorp.com', 'Gateway Group of Companies', 10000, 'Ahmedabad', true, 3);
    httpClientSpy.get.and.returnValue(of([company]));

    //Assert
    service.getById(1).subscribe((data)=>{
      expect(data).toBeTruthy();
      done();
    })
});

//Add company data
it('should add a new company using done', (done)=>{
  //Arrange
  const company = new Company(1, 'gtl@thegatewaycorp.com', 'Gateway Group of Companies', 10000, 'Ahmedabad', true, 3);
  httpClientSpy.post.and.returnValue(of([{}]));

  //Assert
  service.create(company).subscribe((data)=>{
    expect(data).toBeTruthy();
    done();
  })
});

//Update company data
it('should update data an existing company using done', (done)=>{
  //Arrange
  const company = new Company(1, 'gtl@thegatewaycorp.com', 'Gateway Group of Companies', 100, 'Ahmedabad', true, 3);
  httpClientSpy.put.and.returnValue(of([{}]));

  //Assert
  service.update(company).subscribe((data)=>{
    expect(data).toBeTruthy();
    done();
  })
});

//Delete company data
it('should delete a company based on id provided using done', (done)=>{
  //Arrange
  const company = new Company(1, 'gtl@thegatewaycorp.com', 'Gateway Group of Companies', 10000, 'Ahmedabad', true, 3);
  httpClientSpy.delete.and.returnValue(of([{}]));

  //Assert
  service.delete(1).subscribe((data)=>{
    expect(data).toBeTruthy();
    done();
  })
});

});
