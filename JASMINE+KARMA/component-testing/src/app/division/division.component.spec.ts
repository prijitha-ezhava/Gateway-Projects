import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisionComponent } from './division.component';

describe('DivisionComponent', () => {
  let component: DivisionComponent;
  let fixture: ComponentFixture<DivisionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DivisionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });

//Positive test cases
  it(`should perform correct division`, () => {
    //Assert
    const fixture = TestBed.createComponent(DivisionComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.division(10,2)).toEqual(5);
  });

  it(`should be return error message`, () => {
    //Arrange
    const fixture = TestBed.createComponent(DivisionComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.division(10,0)).toEqual('Divided by error occured');
  });

  //Negative Test Cases
  it(`should perform Incorrect Division`, () => {
    //Assert
    const fixture = TestBed.createComponent(DivisionComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.division(10,2)).not.toEqual(3);
  });
});
