13
4050154160129
404964696299752 1761863312843868200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -3.6069531440734863,
    "Y": -9.9621143341064453
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404961620136296:1761863312127119000",
  "next_sibling": "404968201574197:1761863313660601300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404964696552119:1761863312843926300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404964696671745:1761863312843954100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404964696552119:1761863312843926300",
    "DefaultRenderer": "404964696725237:1761863312843966600",
    "DepletedRenderer": "404964696707736:1761863312843962500"
  }
},
{
  "cid": 5,
  "aoid": "404964696684989:1761863312843957600",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
