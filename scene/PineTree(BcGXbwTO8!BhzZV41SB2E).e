13
4694399254529
405057757590460 1761863334527245700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 5.6716375350952148,
    "Y": -12.2924509048461914
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405056469312180:1761863334227075000",
  "next_sibling": "405066411992984:1761863336543730000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405057757957680:1761863334527330100",
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
  "aoid": "405057758110029:1761863334527365600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405057757957680:1761863334527330100",
    "DefaultRenderer": "405057758190783:1761863334527384500",
    "DepletedRenderer": "405057758163607:1761863334527378000"
  }
},
{
  "cid": 5,
  "aoid": "405057758133679:1761863334527371100",
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
