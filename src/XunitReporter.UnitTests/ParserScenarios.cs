﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Vigilant.IntegrationTests;
using Xbehave;

namespace XunitReporter.UnitTests
{
    public class ParserScenarios
    {
        [Scenario]
        public void ShouldParseCorrectlyForSinglePassingScenario()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a single passing scenario in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "singlepassingscenario.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(1);
                    assemblyModel.Passed.Should().Be(1);
                    assemblyModel.Failed.Should().Be(0);
                    assemblyModel.Skipped.Should().Be(0);
                    assemblyModel.Time.Should().Be(0.153M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a single test collection"
                ._(() => result.First().TestCollections.Count.Should().Be(1));

            "And the name of the collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for CommandScratchpad.MyTest");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(1);
                    collectionModel.Failed.Should().Be(0);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.009M);
                });

            "And there should be a single test"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests.First();
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Pass);
                    testModel.Name.Should().Be("MyScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Pass);
                });


        }

        [Scenario]
        public void ShouldParseCorrectlyForMultiplePassingScenariosWithSameNamespaceAndMethodNameButDifferentClassName()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a two passing scenarios in the same namepsace with the same method name but different class names in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "twopassingscenariossameclassnameandmethod.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(2);
                    assemblyModel.Passed.Should().Be(2);
                    assemblyModel.Failed.Should().Be(0);
                    assemblyModel.Skipped.Should().Be(0);
                    assemblyModel.Time.Should().Be(0.138M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a two test collections"
                ._(() => result.First().TestCollections.Count.Should().Be(2));

            "And the first collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for CommandScratchpad.MyTest");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(1);
                    collectionModel.Failed.Should().Be(0);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.009M);
                });

            "And there should be a single test on the first collection model"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests.First();
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Pass);
                    testModel.Name.Should().Be("MyScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Pass);
                });

            "And the second collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections[1];
                    collectionModel.Name.Should().Be(@"Test collection for CommandScratchpad.MyTest2");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(1);
                    collectionModel.Failed.Should().Be(0);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.009M);
                });

            "And there should be a single test on the second collection model"
                ._(() => result.First().TestCollections[1].Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections[1].Tests.First();
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Pass);
                    testModel.Name.Should().Be("MyScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Pass);
                });

        }

        [Scenario]
        public void ShouldParseCorrectlyForMultiplePassingScenariosWithWithinSameClass()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a two passing scenarios in the same class in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "twopassingscenariosinsameclass.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(2);
                    assemblyModel.Passed.Should().Be(2);
                    assemblyModel.Failed.Should().Be(0);
                    assemblyModel.Skipped.Should().Be(0);
                    assemblyModel.Time.Should().Be(0.149M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a one test collection"
                ._(() => result.First().TestCollections.Count.Should().Be(1));

            "And the collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for CommandScratchpad.MyTest");
                    collectionModel.Total.Should().Be(2);
                    collectionModel.Passed.Should().Be(2);
                    collectionModel.Failed.Should().Be(0);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.010M);
                });

            "And there should be a two tests on the collection model"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(2));

            "And the first test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests[0];
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Pass);
                    testModel.Name.Should().Be("MyScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Pass);
                });

            "And the second test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests[1];
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Pass);
                    testModel.Name.Should().Be("AnotherScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given I start with this");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When I do this");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then this happens");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing happens too");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Pass);
                });


        }

        [Scenario]
        public void ShouldParseCorrectlyForSingleFailingScenarioWhenFailureIsNotLastStep()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a single failing scenario in which the second to last step fails in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "singlefailingscenarionotlaststep.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(1);
                    assemblyModel.Passed.Should().Be(0);
                    assemblyModel.Failed.Should().Be(1);
                    assemblyModel.Skipped.Should().Be(0);
                    assemblyModel.Time.Should().Be(0.191M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a single test collection"
                ._(() => result.First().TestCollections.Count.Should().Be(1));

            "And the name of the collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for RandomNamespace.FailingTest");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(0);
                    collectionModel.Failed.Should().Be(1);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.041M);
                });

            "And there should be a single test"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests.First();
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Fail);
                    testModel.Name.Should().Be("MyFailingScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something should be true");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Fail);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing should be true");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Skip);
                });


        }

        [Scenario]
        public void ShouldParseCorrectlyForSingleFailingScenarioWhereFailureIsTheLastStep()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a single failing scenario in which the last step fails in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "singlefailingscenario.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(1);
                    assemblyModel.Passed.Should().Be(0);
                    assemblyModel.Failed.Should().Be(1);
                    assemblyModel.Skipped.Should().Be(0);
                    assemblyModel.Time.Should().Be(0.210M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a single test collection"
                ._(() => result.First().TestCollections.Count.Should().Be(1));

            "And the name of the collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for RandomNamespace.FailingTest");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(0);
                    collectionModel.Failed.Should().Be(1);
                    collectionModel.Skipped.Should().Be(0);
                    collectionModel.Time.Should().Be(0.054M);
                });

            "And there should be a single test"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests.First();
                    testModel.TestSteps.Count.Should().Be(4);
                    testModel.TestResult.Should().Be(TestResult.Fail);
                    testModel.Name.Should().Be("MyFailingScenario");
                    testModel.TestSteps[0].Step.Should().Be("Given something");
                    testModel.TestSteps[0].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[1].Step.Should().Be("When something");
                    testModel.TestSteps[1].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[2].Step.Should().Be("Then something");
                    testModel.TestSteps[2].StepResult.Should().Be(TestResult.Pass);
                    testModel.TestSteps[3].Step.Should().Be("And then another thing should be true");
                    testModel.TestSteps[3].StepResult.Should().Be(TestResult.Fail);
                });


        }

        [Scenario]
        public void ShouldParseCorrectlyForSingleSkippedScenario()
        {
            var result = default(List<TestAssemblyModel>);
            var xml = default(string);

            "Given I have a single skipped scenario in the test result xml"
                ._(() => xml = AssemblyResource.InAssembly(typeof(ParserScenarios).Assembly, "singleskippedscenario.xml").GetText());

            "When I parse the xml"
                ._(() => result = XmlParser.Parse(xml));

            "Then the result should have one assembly model"
                ._(() => result.Count.Should().Be(1));

            "And the name of the assembly model should be correct"
                ._(() =>
                {
                    var assemblyModel = result.First();
                    assemblyModel.Name.Should().Be(@"C:\projects\CommandScratchpad\CommandScratchpad\bin\Debug\CommandScratchpad.EXE");
                    assemblyModel.Total.Should().Be(1);
                    assemblyModel.Passed.Should().Be(0);
                    assemblyModel.Failed.Should().Be(0);
                    assemblyModel.Skipped.Should().Be(1);
                    assemblyModel.Time.Should().Be(0.100M);
                    assemblyModel.Errors.Should().Be(0);
                });

            "And there should be a single test collection"
                ._(() => result.First().TestCollections.Count.Should().Be(1));

            "And the name of the collection model should be correct"
                ._(() =>
                {
                    var collectionModel = result.First().TestCollections.First();
                    collectionModel.Name.Should().Be(@"Test collection for RandomNamespace.FailingTest");
                    collectionModel.Total.Should().Be(1);
                    collectionModel.Passed.Should().Be(0);
                    collectionModel.Failed.Should().Be(0);
                    collectionModel.Skipped.Should().Be(1);
                    collectionModel.Time.Should().Be(0M);
                });

            "And there should be a single test"
                ._(() => result.First().TestCollections.First().Tests.Count.Should().Be(1));

            "And the test should be correct"
                ._(() =>
                {
                    var testModel = result.First().TestCollections.First().Tests.First();
                    testModel.TestSteps.Count.Should().Be(0);
                    testModel.TestResult.Should().Be(TestResult.Skip);
                });


        }
    }
}
