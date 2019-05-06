
enable_language(CSharp)

add_executable(csharp_test main.cs)
set_target_properties(csharp_test PROPERTIES
    VS_DOTNET_REFERENCES "${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/cs/Release/net451/csharp_api.dll"
    VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.5.1"
)

add_dependencies(csharp_test test_api)

add_test(NAME test_encoding COMMAND csharp_test)

set_property(TEST test_encoding PROPERTY FAIL_REGULAR_EXPRESSION "FAILED")
