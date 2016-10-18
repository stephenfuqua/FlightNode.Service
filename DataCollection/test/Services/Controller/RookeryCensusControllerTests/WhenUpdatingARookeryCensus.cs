﻿using FlightNode.DataCollection.Domain.Entities;
using FlightNode.DataCollection.Services.Models.Survey;
using Moq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace FlightNode.DataCollection.Domain.UnitTests.Services.Controller.RookeryCensusControllerTests
{
    public class WhenUpdatingARookeryCensus
    {
        public class HappyPath : Fixture
        {

            public override void Dispose()
            {
                // Restore delegate extension method to default behavior
                ExtensionDelegate.Init();

                base.Dispose();
            }
            [Fact]
            public void MapsPrepTimeHours()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(sp => sp.PrepTimeHours == PrepTime)));
            }

            [Fact]
            public void MapsSubmittedBy()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(sp => sp.SubmittedBy == SubmittedBy)));
            }

            [Fact]
            public void MapsAccessPoint()
            {
                RunPositiveTest();

                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => ACCESS_POINT == y.AccessPointId)));
            }

            [Fact]
            public void MapsDisturbanceComment()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBED == y.DisturbanceComments)));
            }


            [Fact]
            public void MapsEndDate()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DateValuesAreClose(END_DATE, y.EndDate.Value))));
            }



            [Fact]
            public void MapsStartDate()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DateValuesAreClose(START_DATE, y.StartDate.Value))));
            }

            [Fact]
            public void MapsLocationId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => LOCATION_ID == y.LocationId)));
            }

            [Fact]
            public void MapsSiteTypeIdToAssessment()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => SITE_TYPE_ID == y.AssessmentId)));
            }

            [Fact]
            public void MapsSurveyCommentsToGeneralComments()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => SURVEY_COMMENTS == y.GeneralComments)));
            }


            [Fact]
            public void MapsVantagePoint()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => VANTAGE_POINT == y.VantagePointId)));
            }


            [Fact]
            public void MapsDisturbedBehavior()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBED_BEHAVIOR == y.Disturbances.First().Result)));
            }

            [Fact]
            public void MapsDisturbanceTypeId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBED_TYPE_ID == y.Disturbances.First().DisturbanceTypeId)));
            }

            [Fact]
            public void MapsDisturbanceId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBANCE_ID == y.Disturbances.First().Id)));
            }

            [Fact]
            public void MapsDisturbanceDuration()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBED_DURATION == y.Disturbances.First().DurationMinutes)));
            }

            [Fact]
            public void MapsDisturbanceQuantity()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => DISTURBED_QUANTITY == y.Disturbances.First().Quantity)));
            }

            [Fact]
            public void MapsIdentifierIntoDisturbance()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => IDENTIFIER == y.Disturbances.First().SurveyIdentifier)));
            }

            [Fact]
            public void MapsObserver()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => Observers == y.Observers)));
            }

            [Fact]
            public void MapsIdentifierIntoObservation()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => IDENTIFIER == y.Observations.First().SurveyIdentifier)));
            }

            [Fact]
            public void MapsObservationId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => OBSERVATION_ID == y.Observations.First().Id)));
            }

            [Fact]
            public void MapAdultsToBin3()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => NumberOfAdults == y.Observations.First().Bin3)));
            }


            [Fact]
            public void MapChicksPresent()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => ChicksPresent == y.Observations.First().ChicksPresent)));
            }

            [Fact]
            public void MapNestsPresent()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => NestsPresent == y.Observations.First().NestPresent)));
            }

            [Fact]
            public void MapFledglingsPresent()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => FledglingsPresent == y.Observations.First().FledglingPresent)));
            }
            

            [Fact]
            public void MapSpeciesId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => SPECIES_ID == y.Observations.First().BirdSpeciesId)));
            }

            [Fact]
            public void MapsSurveyTypeId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => SurveyType.Rookery == y.SurveyTypeId)));
            }

            [Fact]
            public void MapsSurveyd()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Update(It.Is<SurveyPending>(y => SURVEY_ID == y.Id)));
            }


            [Fact]
            public void RespondsWithOk200()
            {
                HttpResponseMessage result = RunPositiveTest();

                //
                // Assert
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            }


            private HttpResponseMessage RunPositiveTest()
            {
                //
                // Arrange
                RookeryCensusModel input = CreateDefautInput();
                input.SurveyIdentifier = IDENTIFIER;

                MockDomainManager.Setup(x => x.Update(It.IsAny<SurveyPending>()))
                    .Returns<SurveyPending>(actual => actual);

                var system = BuildSystem();

                //
                // Act
                var result = ExecuteHttpAction(system.Put(IDENTIFIER, input));

                return result;
            }



            [Fact]
            public void NullInputShouldBeTreatedAsABadRequest()
            {

                var result = BuildSystem().Put(IDENTIFIER, null).ExecuteAsync(new System.Threading.CancellationToken()).Result;

                Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            }
        }

        public class ExceptionHandling : Fixture
        {

            private HttpResponseMessage RunTest(Exception ex)
            {
                MockDomainManager.Setup(x => x.Update(It.IsAny<SurveyPending>()))
                    .Throws(ex);


                var input = CreateDefautInput();
                input.SurveyIdentifier = IDENTIFIER;

                return BuildSystem().Put(IDENTIFIER, input).ExecuteAsync(new System.Threading.CancellationToken()).Result;
            }

            [Fact]
            public void EmptyGuidIdentifierGeneratesBadRequest()
            {

                //
                // Arrange
                RookeryCensusModel input = CreateDefautInput();

                //
                // Act
                var result = ExecuteHttpAction(BuildSystem().Put(Guid.Empty, input));

                //
                // Assert
                Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            }
        }
    }
}